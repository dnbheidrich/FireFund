import Vue from "vue";
import Router from "vue-router";
// @ts-ignore
import Home from "./views/Home.vue";
// @ts-ignore
import RoomDetails from "./views/RoomDetails.vue";
// @ts-ignore
import CategoryDetails from "./views/CategoryDetails.vue";
// @ts-ignore
import Dashboard from "./views/Dashboard.vue";
import { authGuard } from "@bcwdev/auth0-vue";

Vue.use(Router);

export default new Router({
  routes: [
    {
      path: "/",
      name: "home",
      component: Home
    },
    {
      path: "/dashboard",
      name: "dashboard",
      component: Dashboard,
      beforeEnter: authGuard
    },
    {
      path: "/rooms/:roomId",
      name: "RoomDetails",
      component: RoomDetails,
      beforeEnter: authGuard
    },
    {
      path: "/categories/:categoryId",
      name: "CategoryDetails",
      component: CategoryDetails,
      beforeEnter: authGuard
    },
  ]
});
