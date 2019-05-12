import Vue from "vue";
import Vuex from "vuex";
import axios from "axios";


Vue.use(Vuex);

export default new Vuex.Store({
    state: {
        idToken: null,
        userId: null,
        user: null
    },
    mutations: {
        authUser(state, userData) {
            state.idToken = userData.token;
            state.userId = userData.userId;
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
                    console.log(res)
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
                    console.log(res)
                    commit("authUser", {
                        token: res.data.idToken,
                        userId: res.data.localId
                    })
                })
                .catch(err => console.log(err));
        },
        storeUser({commit}, userData) {
            axios.post("https://bestdiabetesgamegg.firebaseio.com/users.json", userData)
                .then(res => console.log(res))
                .catch(err => console.log(err));
        },
        fetchUser({commit}) {
            axios.get("https://bestdiabetesgamegg.firebaseio.com/users.json")
                .then(res => {
                    const data = res.data;
                    const users = [];
                    for (let key in data) {
                        const user = data[key];
                        user.id = key;
                        users.push(user);
                    }
                    console.log(users);
                    this.email = users[0].email;
                })
                .catch(err => console.log(err));
        }
    },
    getters: {

    }
});
