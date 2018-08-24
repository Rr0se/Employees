<template>
  <div class="cardclass">
    <h2></h2>
    <br/>
    <br/>
    <br/>
    <div class="employee">
      <table class="table table-hover">
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
      <table class="table table-hover">

        <thead>
          <tr>
            <th>Umiejętności</th>
            <th>Doświadczenie w latach</th>
            <th>Stopień</th>
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



    </div>
    <div class="col-lg-4"></div>
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

    axios
      .get("http://localhost:4444/api/skills/GetSkills")
      .then(response => {
        this.skills = response.data;
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
</style>
