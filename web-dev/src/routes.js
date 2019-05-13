import Home from "./components/pages/Home.vue";
import AboutUs from "./components/pages/AboutUs.vue";
import Game from "./components/Game.vue";
import UserProfile from "./components/auth/UserProfile.vue";
import store from "./store";
import Signin from "./components/auth/Signin.vue";
import Signup from "./components/auth/Signup.vue";

export const routes = [
    {path: "/", component: Home,
        beforeEnter(to, from, next) {
            if (store.state.idToken) {
                next();
            } else {
                next("/signin");
            }
        }
    },
    {path: "/aboutus", component: AboutUs,
        beforeEnter(to, from, next) {
            if (store.state.idToken) {
                next();
            } else {
                next("/signin");
            }
        }
    },
    {path: "/game", component: Game,
        beforeEnter(to, from,next) {
            if (store.state.idToken) {
                next();
            } else {
                next("/signin");
            }
        }
    },
    {path: "/profile", component: UserProfile,
        beforeEnter(to, from, next) {
            if (store.state.idToken) {
                next();
            } else {
                next("/signin");
            }
        }
    },
    {path: "/signin", component: Signin},
    {path: "/register", component: Signup},
    {path: "/*", redirect: "/"},
    
];