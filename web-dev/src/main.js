import Vue from 'vue'
import App from './App.vue';
import VueRouter from "vue-router";
import BootstrapVue from 'bootstrap-vue';
import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap-vue/dist/bootstrap-vue.css';
import {routes} from "./routes";


Vue.use(VueRouter);
Vue.use(BootstrapVue);
Vue.config.productionTip = false;

const router = new VueRouter({
    routes,
    mode: "history"
});


new Vue({
    el: "#app",
    router,
    render: h => h(App),
});

