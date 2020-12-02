
<template>
  <div>
    <div class="jumbotron p-3 p-md-5 text-white rounded bg-dark">
    <div class="col-md-6 px-0">
      <h1 class="display-6 font-italic bold">FILMES</h1>
    </div>
  </div>

  <form>
    <div class="form-group">
      <label for="nome">Nome</label>
      <input type="hidden" id="id" name="id">
      <input type="text" class="form-control" v-model="filme.nome" id="nome" name="nome" placeholder="Digite o nome">
    </div>
    <div class="form-group">
      <label for="genero">Gênero</label>
      <input type="text" class="form-control" v-model="filme.genero" id="endereco" name="endereco" placeholder="Digite o Endereço">
    </div>
    <button v-on:click="salvar()" type="button" class="btn btn-primary">Enviar</button>
    <div style="color: red">
      {{mensagem}}
    </div>
  </form>
  
    <table class="table">
      <thead>
        <tr>
          <th>
            Id
          </th>
          <th>
            Nome
          </th>
          <th>
            Gênero
          </th>
          <th colspan="2">
          </th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="filme in filmes" v-bind:key="filme.id">
          <th>
            {{filme.id}}
          </th>
          <th>
            {{filme.nome}}
          </th>
          <th>
            {{filme.genero}}
          </th>
          <th>
            <button class="btn btn-primary" v-on:click="editar(filme)">Editar</button>
          </th>
          <th>
            <button class="btn btn-danger" v-on:click="excluir(filme.id)">Excluir</button>
          </th>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import axios from 'axios';
const URL = "https://backend-apiba.azurewebsites.net/api/filmes/";
export default {
  name: 'Filmes',
  props: {
    msg: String
  },
  data:() => {
    return {
      filmes: [],
      filme: {nome:"", genero:""},
      mensagem: ""
    }
  },
  methods:  {
    lista() {
      this.filme = {nome:"", genero:""}
      axios.get(URL).then((res) =>{
      console.log(res)
      this.filmes = res.data
      })      
    },
    salvar() {
      if(this.filme.id){
        this.alterar()
        return
      }
      axios.post(URL, this.filme).then(() => {
        this.lista()
      })
    },
    editar(filme) {
        this.filme = filme
    },
    alterar() {
       axios.put(URL + this.filme.id, this.filme).then(() => {
        this.lista()
        this.filme = {nome:"", genero:""}
      })
    },
    excluir(id) {
      if(confirm("Confirma a exclusão?")){
        axios.delete(URL + id).then(() => {
          this.lista()
        })
      }
    }
  },
  created(){
    this.lista()
  }
}
</script>