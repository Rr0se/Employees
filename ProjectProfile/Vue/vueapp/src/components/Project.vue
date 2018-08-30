<template>
  <div class="projectclass">
    <h1></h1>


    <br/>
    <br/>
    <br/>
    <div class="col-lg-4"></div>
    <div class="col-lg-4">
      <router-link to="/addproject">
        <button type="button" class="btn btn-primary btn-outline" style="float:left; margin-bottom:20px;">Dodaj projekt</button>
      </router-link>

      <div v-for="p in projects" :key="p.Id">
        <table class="table table-hover" border="1">
          <tr class="table-tittle">
            <td align="left" class="text-color">
              <h4> {{p.name}}</h4>
              <h4>{{p.title}}</h4>
            </td>
            <td></td>
          </tr>

          <tr>
            <td align="left">
              Sector:
            </td>
            <td align="right">
              {{p.clientSector}}

            </td>
          </tr>

          <tr>
            <td align="left">
              Technologie:
            </td>
            <td align="right">
              <template v-for="t in p.technology">
                {{t.name}}
              </template>

            </td>
          </tr>

          <tr>
            <td align="left">
              Start:
            </td>
            <td align="right">
              {{p.startDate}}

            </td>
          </tr>

          <tr>
            <td align="left">
              Koniec:
            </td>
            <td align="right">
              {{p.endDate}}
            </td>
          </tr>


          <div v-for="emp in p.profiles" :key="emp.Id">
            <table class="table table-hover" border="1">
              <tr>
                <td align="left">
                  Pracownicy:
                </td>

                <td align="right">
                  {{emp.name}} {{emp.lastName}}
                </td>
              </tr>
            </table>
          </div>
        </table>



        <td style="margin-left:5px;">
          <button type="button" class="btn btn-primary btn-outline" style="float:right">Usuń</button>
          <router-link to="/editproject">
            <button type="button" class="btn btn-primary btn-outline" style="float:right">Edytuj</button>
          </router-link>
        </td>
      </div>
    </div>

    <div class="col-lg-4"></div>

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
      projects: [],
      errors: []
    };
  },

  // Fetches posts when the component is created.
  created() {
    axios
      .get(`http://localhost:4444/api/projects/GetProjects`)
      .then(response => {
        console.log("asdaqwe");
        // JSON responses are automatically parsed.
        this.projects = response.data;
      })
      .catch(e => {
        this.errors.push(e);
      });
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
