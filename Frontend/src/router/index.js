import { createRouter, createWebHashHistory } from 'vue-router'
import Home from '../views/Home.vue'

const routes = [
  {path: '/', name: 'Home', component: Home},
  {path: '/locadora', name: 'Locadora', component: () => import('../components/Locadora.vue')},
  {path: '/filmes', name: 'Filmes', component: () => import('../views/Filmes.vue')},
  {path: '/diretores', name: 'Diretores', component: () => import('../views/Diretores.vue')},
  {path: '/sobre', name: 'Sobre', component: () => import('../views/Sobre.vue')}
]

const router = createRouter({
  history: createWebHashHistory(),
  mode: "history",
  routes: routes
})

export default router
