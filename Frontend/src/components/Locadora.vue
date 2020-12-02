
<template>
  <div>
    <div class="jumbotron p-3 p-md-5 text-white rounded bg-dark">
    <div class="col-md-6 px-0">
      <h1 class="display-6 font-italic bold">LOCADORAS</h1>
    </div>
  </div>

  <form>
    <div class="form-group">
      <label for="nome">Nome</label>
      <input type="hidden" id="id" name="id">
      <input type="text" class="form-control" v-model="locadora.nome" id="nome" name="nome" placeholder="Digite o nome">
    </div>
    <div class="form-group">
      <label for="endereco">Endereço</label>
      <input type="text" class="form-control" v-model="locadora.endereco" id="endereco" name="endereco" placeholder="Digite o Endereço">
    </div>
    <div class="form-group">
      <label for="telefone">Telefone</label>
      <input type="tel" class="form-control" v-model="locadora.telefone" id="telefone" name="telefone" placeholder="Digite o Telefone">
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
            Endereço
          </th>
          <th>
            Telefone
          </th>
          <th colspan="2">
          </th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="locadora in locadoras" v-bind:key="locadora.id">
          <th>
            {{locadora.id}}
          </th>
          <th>
            {{locadora.nome}}
          </th>
          <th>
            {{locadora.endereco}}
          </th>
          <th>
            {{locadora.telefone}}
          </th>
          <th>
            <button class="btn btn-primary" v-on:click="editar(locadora)">Editar</button>
          </th>
          <th>
            <button class="btn btn-danger" v-on:click="excluir(locadora.id)">Excluir</button>
          </th>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import axios from 'axios';
const URL = "https://backend-apiba.azurewebsites.net/api/locadora/";
export default {
  name: 'Locadora',
  props: {
    msg: String
  },
  data:() => {
    return {
      locadoras: [],
      locadora: {nome:"", endereco:"", telefone:""},
      mensagem: ""
    }
  },
  methods:  {
    lista() {
      this.locadora = {nome:"", endereco:"", telefone:""}
      axios.get(URL).then((res) =>{
      console.log(res)
      this.locadoras = res.data
      })      
    },
    salvar() {
      if(this.locadora.id){
        this.alterar()
        return
      }
      axios.post(URL, this.locadora).then(() => {
        this.lista()
      })
    },
    editar(locadora) {
        this.locadora = locadora  
    },
    alterar() {
       axios.put(URL + this.locadora.id, this.locadora).then(() => {
        this.lista()
        this.locadora = {nome:"", endereco:"", telefone:""}
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