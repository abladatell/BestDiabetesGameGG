import Home from "./components/pages/Home.vue";
import AboutUs from "./components/pages/AboutUs.vue";
import Game from "./components/Game.vue";
import Login from "./components/pages/Login.vue"
import Register from "./components/pages/Register.vue"

export const routes = [
    {path: "/", component: Login},
    {path: "/home", component: Home},
    {path: "/aboutus", component: AboutUs},
    {path: "/game", component: Game},
    {path: "/register", component: Register},
    {path: "/*", redirect: "/"}
];