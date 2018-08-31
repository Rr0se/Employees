<template>
  <div class="employeeclass container">
    <h1></h1>

    <br/>
    <br/>
    <br/>

    <div class="col-lg-3"></div>
    <div class="col-lg-6">
      <router-link to="/addemployee">
        <button type="button" class="btn btn-primary btn-outline" style="float:left; margin-bottom:20px; ">Dodaj pracownika</button>
      </router-link>

      <table class="table table-hover" border="1">
        <thead>
          <tr class="table-tittle">
            <th class="text-color">Imie</th>
            <th class="text-color" colspan="3">Nazwisko</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="emp in employees" :key="emp.Id">
           
            <td align="left">{{emp.profile.name}}</td>
            <td align="left">{{emp.profile.lastName}}</td>
            
            <td>
              <router-link to="/editemployee">
                <button type="button" class="btn btn-primary btn-outline" style="float:right">Edytuj</button>
              </router-link>
              <button type="submit" class="btn btn-primary btn-outline" style="float:right" v-on:click="deleteEmployee">Usuń</button>
              <button type="button" class="btn btn-primary btn-outline" style="float:right" v-on:click="cardEmployee(emp.profile.id)">Karta</button>
            </td>

          </tr>
        </tbody>
      </table>
    </div>
    <div class="col-lg-3"></div>
  </div>
</template>

<script>
// https://alligator.io/vuejs/rest-api-axios/
// Access-Control-Allow-Origin: *

import axios from "axios";
import router from "../router";

export default {
  data() {
    return {
      employees: [],
      errors: [],
      alert: ""
    };
  },

  // Fetches posts when the component is created.
  created() {
    axios
      .get("http://localhost:4444/api/employees/GetEmployees")
      .then(response => {
        this.employees = response.data;
      })
      .catch(e => {
        this.errors.push(e);
      });
  },

  methods: {
    deleteEmployee() {
      axios
        .delete("http://localhost:4444/api/employees/Delete", {
          body: this.employees
        })
        .then(response => {});
    },

    cardEmployee(id) {
      router.push({
        path: `/card?id=` + id
      });
    }
  }
};
</script>


<style scoped>
h1,
h2 {
  font-weight: normal;
}

ul {
  list-style-type: none;
  padding: 0;
}

li {
  display: inline-block;
  margin: 0 10px;
}

a {
  color: #42b983;
}

.table-tittle {
  background: #f64a35;
}

.text-color {
  color: white;
}
.table-hover {
  border-color: lightgrey;
  border: lightgrey;
}
</style>
