import Home from "./components/pages/Home.vue";
import AboutUs from "./components/pages/AboutUs.vue";
import Game from "./components/Game.vue";
import UserProfile from "./components/auth/UserProfile.vue";
import store from "./store";
import Signin from "./components/auth/Signin.vue";
import Signup from "./components/auth/Signup.vue";
import Content1 from "./components/pages/Content1.vue";
import Content2 from "./components/pages/Content2.vue";
import MobileGame from "./components/MobileGame.vue";
import Error from "./components/pages/404.vue";

export const routes = [
    {path: "/content1", component: Content1,
        beforeEnter(to, from, next) { //redirects to signin page if not logged in
            if (store.state.idToken) {
                next();
            } else {
                next("/signin");
            }
        }
    },
    {path: "/content2", component: Content2,
        beforeEnter(to, from, next) {
            if (store.state.idToken) {
                next();
            } else {
                next("/signin");
            }
        }
    },
    {path: "/game", component: Game,
        beforeEnter(to, from, next) {
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
    {path: "/aboutus", component: AboutUs,
        beforeEnter(to, from, next) {
            if (store.state.idToken) {
                next();
            } else {
                next("/signin");
            }
        }
    },
    {path: "/mobile", component: MobileGame},
    {path: "/signin", component: Signin},
    {path: "/register", component: Signup},
    {path: "/", component: Home,
        beforeEnter(to, from, next) {
            if (store.state.idToken) {
                next();
            } else {
                next("/signin");
            }
        }
    },
    {path: "/error", component: Error},
    {path: "/*", redirect: "/error"}, //redirects to error page when page is not found
    
];