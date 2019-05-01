import Home from "./components/pages/Home.vue";
import Link1 from "./components/pages/Link1.vue";
<<<<<<< HEAD
=======
import Game from "./components/Game.vue";
>>>>>>> f740980a3ddd7fa830109fbc3dfa10595f1aaa3c

export const routes = [
    {path: "", component: Home},
    {path: "/link1", component: Link1},
<<<<<<< HEAD
=======
    {path: "/game", component: Game},
>>>>>>> f740980a3ddd7fa830109fbc3dfa10595f1aaa3c
    {path: "/*", redirect: "/"}
];