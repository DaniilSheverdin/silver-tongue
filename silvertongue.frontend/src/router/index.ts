import Vue from 'vue'
import VueRouter, { RouteConfig } from 'vue-router'
import Home from '../views/Home.vue'
import Tests from '../views/Tests.vue'
import Login from '../views/Login.vue';
import Checker from '../views/Checker.vue';
import Register from '../views/Register.vue';

Vue.use(VueRouter)

const routes: Array<RouteConfig> = [
  {
    path: '/',
    name: 'home',
    component: Home
  },
  {
    path: '/tests',
    name: 'tests',
    component: Tests
  },
  {
    path: '/register',
    name: 'register',
    component: Register
  },
  {
    path: '/checker',
    name: 'checker',
    component: Checker
  },
  {
    path: '/login',
    name: 'login',
    component: Login
  }
]



const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

router.beforeEach((to, from, next) => {
  const publicPages = ['/login', '/register'];
  const authRequired = !publicPages.includes(to.path);
  const loggedIn = localStorage.getItem('user');
  // trying to access a restricted page + not logged in
  // redirect to login page
  if (authRequired && !loggedIn) {
    next('/login');
  } else {
    next();
  }
});
export default router
