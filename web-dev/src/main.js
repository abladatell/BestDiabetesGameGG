import Vue from 'vue'
import App from './App.vue';
import VueRouter from "vue-router";
import BootstrapVue from 'bootstrap-vue';
import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap-vue/dist/bootstrap-vue.css';
import {routes} from "./routes";

<<<<<<< HEAD
=======


>>>>>>> f740980a3ddd7fa830109fbc3dfa10595f1aaa3c
Vue.use(VueRouter);
Vue.use(BootstrapVue);
Vue.config.productionTip = false;

const router = new VueRouter({
  routes,
  mode: "history"
});

<<<<<<< HEAD
=======

>>>>>>> f740980a3ddd7fa830109fbc3dfa10595f1aaa3c
new Vue({
  el: "#app",
  router,
  render: h => h(App),
})
