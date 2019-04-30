import Home from "./components/pages/Home.vue";
import Link1 from "./components/pages/Link1.vue";
import Game from "./components/Game.vue";

export const routes = [
    {path: "", component: Home},
    {path: "/link1", component: Link1},
    {path: "/game", component: Game},
    {path: "/*", redirect: "/"}
];