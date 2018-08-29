<template>
  <div class="cardclass">
    <h2></h2>
    <br/>
    <br/>
    <br/>

    <div class="employee">
      <table class="table table-hover" >
        <thead>
          <h1>
            <p>{{employee.profile.name}}</p>
          </h1>
          <h2>
            <p> {{employee.profile.specialization}}</p>
          </h2>
          <h5>
            <p>Rating: {{employee.profile.rating}} </p>
          </h5>
          <h5>
            <p>Overall Tenure: {{employee.profile.overallTenure}}</p>
          </h5>
        </thead>
      </table>
    </div>


    <div class="col-lg-4"></div>
    <div class="col-lg-4">


      <table class="table table-hover" border="1">
        <thead>
          <tr class="table-tittle">
            <th class="text-color">Umiejętności</th>
            <th class="text-color">Doświadczenie w latach</th>
            <th class="text-color">Stopień</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="skill in employee.skills" :key="skill.Id">
            <td>{{skill.name}}</td>
            <td>{{skill.experience}}</td>
            <td>{{skill.profficiency}}</td>
          </tr>
        </tbody>
      </table>

      <div v-for="p in employee.projects" :key="p.Id">
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
        </table>
      </div>


      <table class="table table-hover" border="1">
        <thead>
          <tr class="table-tittle">
            <th class="text-color">Język</th>
            <th class="text-color">Stopień w mowie</th>
            <th class="text-color">Stopień w piśmie</th>
            <th class="text-color">Stopień w czytaniu</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="lang in employee.languages" :key="lang.Id">
            <td align="left">{{lang.name}}</td>
            <td align="left">{{lang.speaking}}</td>
            <td align="left">{{lang.writing}}</td>
            <td align="left">{{lang.reading}}</td>
          </tr>
        </tbody>
      </table>

      <div class="col-lg-4"></div>
    </div>
  </div>

</template>

<script>
// https://alligator.io/vuejs/rest-api-axios/
// Access-Control-Allow-Origin: *

import axios from "axios";

export default {
  data() {
    return {
      employee: {},
      errors: []
    };
  },

  // Fetches posts when the component is created.
  created() {
    var id = this.getUrlParameter("id");
    axios
      .get(`http://localhost:4444/api/employees/GetEmployee?id=` + id)
      .then(response => {
        // JSON responses are automatically parsed.
        this.employee = response.data;
      })
      .catch(e => {
        this.errors.push(e);
      });
  },
  methods: {
    getUrlParameter(name) {
      var results = new RegExp("[?&]" + name + "=([^&#]*)").exec(
        window.location.href
      );
      if (results == null) {
        return null;
      } else {
        return decodeURI(results[1]) || 0;
      }
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
