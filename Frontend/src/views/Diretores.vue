
<template>
  <div>
    <div class="jumbotron p-3 p-md-5 text-white rounded bg-dark">
    <div class="col-md-6 px-0">
      <h1 class="display-6 font-italic bold">DIRETORES</h1>
    </div>
  </div>

  <form>
    <div class="form-group">
      <label for="nome">Nome</label>
      <input type="hidden" id="id" name="id">
      <input type="text" class="form-control" v-model="diretor.nome" id="nome" name="nome" placeholder="Digite o nome">
      <input type="text" class="form-control" v-model="diretor.filmeId" id="filmeId" name="fid" placeholder="Digite o ID do Filme">
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
            FilmeId
          </th>
          <th colspan="2">
          </th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="diretor in diretores" v-bind:key="diretor.id">
          <th>
            {{diretor.id}}
          </th>
          <th>
            {{diretor.nome}}
          </th>
          <th>
            {{diretor.filmeId}}
          </th>
           <th>
            <button class="btn btn-primary" v-on:click="editar(diretor)">Editar</button>
          </th>
          <th>
            <button class="btn btn-danger" v-on:click="excluir(diretor.id)">Excluir</button>
          </th>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import axios from 'axios';
const URL = "https://backend-apiba.azurewebsites.net/api/diretores/";
export default {
  name: 'Diretores',
  props: {
    msg: String
  },
  data:() => {
    return {
      diretores: [],
      diretor: {nome:"", filmeId:""},
      mensagem: ""
    }
  },
  methods:  {
    lista() {
      this.diretor = {nome:"", filmeId:""}
      axios.get(URL).then((res) =>{
      console.log(res)
      this.diretores = res.data
      })      
    },
    salvar() {
      axios.post(URL,
      {
      nome: document.getElementById("nome").value,
      filmeId: document.getElementById("filmeId").value
      }).then(()=>{
        this.lista(this)
      })
    },
    editar(diretor) {
        this.diretor = diretor
    },
    alterar() {
       axios.put(URL + this.diretor.id, this.diretor).then(() => {
        this.lista()
        this.diretor = {nome:"", filmeId:""}
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