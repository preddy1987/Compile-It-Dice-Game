import Vue from 'vue';
import Router from 'vue-router';
import DashboardView from '@/views/DashboardView';
import JoinView from '@/views/JoinView';
import LandingView from '@/views/LandingView';
import GameOverView from '@/views/GameOverView';
import DirectionsView from '@/views/DirectionsView';
import NewsFeedView from '@/views/NewsFeedView';
import CreditsView from '@/views/CreditsView';

Vue.use(Router);

const router = new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/',
      name: 'landing',
      component: LandingView
    },
    {
      path: '/gameover',
      name: 'gameover',
      component: GameOverView
    },
    {
      path: '/dashboard',
      name: 'dashboard',
      component: DashboardView
    },
    {
      path: '/join',
      name: 'join',
      component: JoinView
    },
    {
      path: '/directions',
      name: 'directions',
      component: DirectionsView
    },
    {
      path: '/news',
      name: 'news',
      component: NewsFeedView
    },
    {
      path: '/credits',
      name: 'credits',
      component: CreditsView
    }
  ],
});

// router.beforeEach((to, from, next) => {
//   // redirect to login page if not logged in and trying to access a restricted page
//   const publicPages = ['/login', '/register'];
//   const authRequired = !publicPages.includes(to.path);
//   const loggedIn = auth.getUser();

//   if (authRequired && !loggedIn) {
//     return next('/login');
//   }

//   next();
// });

export default router;
