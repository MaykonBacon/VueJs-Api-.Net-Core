<template>
  <div class="container" id="app">
    <div class="nav-scroller py-1 mb-2">
      <nav class="nav d-flex justify-content-between">
        <router-link link to="/" class="p-2 text-muted">Início</router-link>
        <router-link link to="/locadora" class="p-2 text-muted">Locadoras</router-link>
        <router-link link to="/filmes" class="p-2 text-muted">Filmes</router-link>
        <router-link link to="/diretores" class="p-2 text-muted">Diretores</router-link>
        <router-link link to="/sobre" class="p-2 text-muted">Sobre</router-link>
      </nav>
    </div>
  </div>
  <router-view/>
</template>