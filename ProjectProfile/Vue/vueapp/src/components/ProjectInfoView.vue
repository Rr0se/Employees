<template>
  <div id="info">
    <h1 style="margin-top:20px;"></h1>



    <h1>Pracownik</h1>
    <div class="col-lg-4"></div>
    <div class="col-lg-4">
      <table class="table table-hover">
        <thead>
          <tr>
            <th>Imie</th>
            <th>Nazwisko</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="emp in employees" :key="emp.Id">
            <td align="left">{{emp.profile.name}}</td>
            <td align="left">{{emp.profile.lastName}}</td>
          </tr>
        </tbody>
      </table>
    </div>
    <div class="col-lg-4"></div>

    <br>
    <br>
    <br>
    <br>
    <br>

    <div style="clear:both"></div>
    <h1>Projekt</h1>
    <div class="col-lg-4"></div>
    <div class="col-lg-4">
      <table class="table table-hover">
        <thead>
          <tr>
            <th>Projekt</th>
            <th>Sektor</th>
            <th>Technologie</th>
            <th>Data początkowa</th>
            <th>Data końcowa</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <tr v-for="p in projects" :key="p.Id">
              <td align="left">{{p.profileProject.name}}</td>
              <td align="left">{{p.profileProject.clientSector}}</td>
              <td align="left">{{p.profileProject.technologies}}</td>
              <td align="left">{{p.profileProject.startDate}}</td>
              <td align="left">{{p.profileProject.endDate}}</td>

            </tr>
        </tbody>
      </table>
    </div>
    <div class="col-lg-4"></div>


  </div>
</template>

<script>
import axios from "axios";

export default {
  data() {
    return {
      projects: [],
      employees: [],
      errors: []
    };
  },

  // Fetches posts when the component is created.
  created() {
    var id = this.getUrlParameter("id");
    axios
      .get(`http://localhost:4444/api/projects/GetProject?id=` + id)
      .then(response => {
        console.log("asdaqwe");
        // JSON responses are automatically parsed.
        this.projects = response.data;
      })
      .catch(e => {
        this.errors.push(e);
      });

    axios
      .get("http://localhost:4444/api/employees/GetEmployees")
      .then(response => {
        this.employees = response.data;
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
