import Home from "./components/pages/Home.vue";
import AboutUs from "./components/pages/AboutUs.vue";
import Game from "./components/Game.vue";
import UserProfile from "./components/auth/UserProfile.vue"

export const routes = [
    {path: "/", component: Home},
    {path: "/aboutus", component: AboutUs},
    {path: "/game", component: Game},
    {path: "/profile", component: UserProfile},
    {path: "/*", redirect: "/"}
];