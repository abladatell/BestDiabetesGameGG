import Home from "./components/pages/Home.vue";
import Link1 from "./components/pages/Link1.vue";

export const routes = [
    {path: "", component: Home},
    {path: "/link1", component: Link1},
    {path: "/*", redirect: "/"}
];