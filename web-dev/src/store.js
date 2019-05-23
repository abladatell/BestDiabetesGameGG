import Vue from "vue";
import Vuex from "vuex";
import axios from "axios";
import createPersistedState from "vuex-persistedstate";


Vue.use(Vuex);

export default new Vuex.Store({
    state: {
        idToken: null,
        userId: null,
        user: null,
        board: []
    },
    mutations: {
        authUser(state, userData) {
            state.idToken = userData.token;
            state.userId = userData.userId;
        },
        storeUser1(state, user) {
            state.user = user;
        },
        clearToken(state) {
            state.idToken = null;
        },
        pushData(state, data) {
            state.board = data;
        }
    },
    actions: {
        //firebase expects email(String), password(String), returnSecureToken(boolean)
        signup({commit, dispatch}, authData) {
            axios.post("/signupNewUser?key=AIzaSyDawwbtIoB7M-yaW2qJK8lnO89H4cHui0I", {
                email: authData.email,
                password: authData.password,
                returnSecureToken: true
            })
                .then(res => {
                    commit("authUser", {
                        token: res.data.idToken,
                        userId: res.data.localId
                    });
                    dispatch("storeUser", authData);
                })
                .catch(err => console.log(err));
        },
        login({commit}, authData) {
            axios.post("/verifyPassword?key=AIzaSyDawwbtIoB7M-yaW2qJK8lnO89H4cHui0I", {
                email: authData.email,
                password: authData.password,
                returnSecureToken: true
            })
                .then(res => {
                    commit("authUser", {
                        token: res.data.idToken,
                        userId: res.data.localId
                    })
                })
                .catch(err => console.log(err));
        },
        storeUser({commit, state}, userData) {
            let userData2 = {
                email: userData.email,
                terms: userData.terms
            }
            if (!state.idToken) {//if idToken is null
                console.log("id token is null from storeUser");
                return;
            }
            axios.post(`https://bestdiabetesgamegg.firebaseio.com/users.json?auth=${state.idToken}`, userData2)
                .then(res => console.log(res))
                .catch(err => console.log(err));
        },
        fetchUser({commit, state}) {
            if (!state.idToken) {
                console.log("idToken is null from fetchUser");
                return;
            }
            axios.get(`https://bestdiabetesgamegg.firebaseio.com/users.json?auth=${state.idToken}`)
                .then(res => {
                    const data = res.data;
                    const users = [];
                    for (let key in data) {
                        const user = data[key];
                        user.id = key;
                        users.push(user);
                    }
                    console.log(users);
                    commit("storeUser1", users[0]);
                })
                .catch(err => console.log(err));
        },
        logout(vuexContext) {
            vuexContext.commit("clearToken");
        }
    },
    getters: {
        user(state) {
            return state.user;
        },
        isAuthenticated(state) {
            return state.idToken !== null;
        }
    },
    plugins: [createPersistedState()] //stores logged in data in local storage of browser
});

