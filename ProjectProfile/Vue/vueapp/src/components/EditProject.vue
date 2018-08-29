<template>
  <div class="addproject">
    <bt/>
    <h1></h1>
    <h2></h2>
    <div class="col-lg-5"></div>
    <div class="col-lg-2">
      <form>
        <div class="form-group">
          <label for="Title">Tytuł</label>
          <input type="Title" class="form-control" id="Title" placeholder="Tytuł">
        </div>

        <div class="form-group">
          <label for="ClientSector">Sektor klienta</label>
          <input type="ClientSector" class="form-control" id="ClientSector" placeholder="Sektor klienta">
        </div>

        <div class="form-group">
          <label for="Technologies">Technologie</label>
          <input type="Technologies" class="form-control" id="Technologies" placeholder="Technologie">
        </div>

        <div class="form-group">
          <label for="StartDate">Data rozpoczęcia projektu</label>
          <input type="StartDate" class="form-control" id="StartDate" placeholder="Data rozpoczęcia projektu">
        </div>

        <div class="form-group">
          <label for="EndDate">Data zakończenia projektu</label>
          <input type="EndDate" class="form-control" id="EndDate" placeholder="Data zakończenia projektu">
        </div>

        <div class="form-group">
          <table class="table table-hover">
            <thead>
              <tr>
                <th>Pracownik</th>
                <th>
                  <div class="text-left m-t-sm m-b-md">
                    <select v-model="selectedemployee" style="float:left;width: 160px">
                      <option v-for="emp in employees" :key="emp.Id">
                        {{ emp.profile.name }} {{ emp.profile.lastName }}
                      </option>
                    </select>
                  </div>
                </th>
              </tr>
            </thead>
          </table>
        </div>

        <div class="form-group">
          <table class="table table-hover">
            <thead>
              <tr>
                <th>Technologie</th>
                <th>
                  <div class="text-left m-t-sm m-b-md">
                    <select v-model="selectedtechnologies" style="float:left;width: 160px">
                      <option v-for="techno in technologies" :key="techno.Id">
                        {{techno.technologyName}}
                      </option>
                    </select>
                  </div>
                </th>
              </tr>
            </thead>
          </table>
        </div>

        <button type="submit" class="btn btn-primary btn-outline">Zapisz zmiany</button>
        <router-link to="/project">
          <button type="submit" class="btn btn-primary btn-outline">
            Wróć</button>
        </router-link>
      </form>
    </div>
    <div class="col-lg-5"></div>
  </div>
</template>

<script>
// https://alligator.io/vuejs/rest-api-axios/
// Access-Control-Allow-Origin: *

import axios from "axios";

export default {
  data() {
    return {
      employees: [],
      technologies: [],
      errors: [],
      selectedemployee: [],
      selectedtechnologies: [],
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

    axios
      .get("http://localhost:4444/api/technologies/GetTechnologies")
      .then(response => {
        this.technologies = response.data;
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
</style>
