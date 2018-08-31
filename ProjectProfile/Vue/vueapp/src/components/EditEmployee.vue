<template>
  <div class="addemployee">
    <bt/>
    <h1></h1>
    <h2></h2>

    <div class="col-lg-4"></div>
    <div class="col-lg-4">

<!--<table class="table table-hover" border="1">
  
  
  
  
  
  
  -->



      <table class="table table-hover">
        <tr>
          <td style="float:left">
            <label for="Name">Imie</label>
          </td>
          <td>
            <input type="Name" class="form-control" id="Name" placeholder="Imie">
          </td>
        </tr>
      </table>

      <table class="table table-hover">
        <tr>
          <td style="float:left">
            <label for="LastName">Nazwisko</label>
          </td>
          <td>
            <input type="LastName" class="form-control" id="LastName" placeholder="Nazwisko">
          </td>
        </tr>
      </table>

      <table class="table table-hover">
        <tr>
          <td style="float:left">
            <label for="LastName">Specjalizacja</label>
          </td>
          <td>
            <input type="Specialization" class="form-control" id="Specialization" placeholder="Specjalizacja">
          </td>
        </tr>
      </table>

      <table class="table table-hover">
        <tr>
          <b>
            <td style="float:left">Ocena</td>
          </b>
          <div class="text-left m-t-sm m-b-md" style="float:left">
          </div>

          <td>
            <input id="1" value="1" v-model="pickedrating" type="radio">
            <label for="1">1</label>
          </td>

          <td>
            <input type="radio" id="2" value="2" v-model="pickedrating">
            <label for="2">2</label>
          </td>

          <td>
            <input type="radio" id="3" value="3" v-model="pickedrating">
            <label for="3">3</label>
          </td>
        </tr>
      </table>

      <table class="table table-hover">
        <thead>
          <td style="float:left">
            <label for="LastName">Kadencja</label>
          </td>
        </thead>
        <tbody>
          <td>
            <input type="YearsOfWork" class="form-control" id="YearsOfWork" placeholder="Ilość przepracowanych lat">
          </td>
        </tbody>
      </table>


      <div class="form-group">
        <table class="table table-hover" s>
          <tr>
            <b>
              <td style="float:left">Projekt</td>
            </b>
            <td>
              <div class="text-left m-t-sm m-b-md">
                <select v-model="selectedsproject" style="float:left;width: 160px">
                  <option v-for="proj in projects" :key="proj.Id">
                    {{ proj.name }}
                  </option>
                </select>
              </div>
            </td>
          </tr>
        </table>

        <div class="form-group">
          <table class="table table-hover">
            <tr>
              <b>
                <td style="float:left">Język</td>
              </b>
              <td>
                <div class="text-left m-t-sm m-b-md">
                  <select v-model="selectedlanguage" style="float:left;width: 160px">
                    <option v-for="lang in languages" :key="lang.Id">
                      {{ lang.languageName }}
                    </option>
                  </select>
                </div>
              </td>
            </tr>
          </table>

          <table class="table table-hover">
            <tr>
              <b>
                <td style="float:left">Stopień w mowie</td>
              </b>
              <div class="text-left m-t-sm m-b-md" style="float:left">
              </div>

              <td>
                <input id="1" value="1" v-model="pickedspeak" type="radio">
                <label for="1">1</label>
              </td>

              <td>
                <input type="radio" id="2" value="2" v-model="pickedspeak">
                <label for="2">2</label>
              </td>

              <td>
                <input type="radio" id="3" value="3" v-model="pickedspeak">
                <label for="3">3</label>
              </td>
            </tr>
          </table>

          <table class="table table-hover">
            <tr>
              <b>
                <td style="float:left">Stopień w czytaniu</td>
              </b>
              <div class="text-left m-t-sm m-b-md" style="float:left">
              </div>

              <td>
                <input id="1" value="1" v-model="pickedread" type="radio">
                <label for="1">1</label>
              </td>

              <td>
                <input type="radio" id="2" value="2" v-model="pickedread">
                <label for="2">2</label>
              </td>

              <td>
                <input type="radio" id="3" value="3" v-model="pickedread">
                <label for="3">3</label>
              </td>
            </tr>
          </table>

          <table class="table table-hover">
            <tr>
              <b>
                <td style="float:left">Stopień w pisaniu</td>
              </b>
              <div class="text-left m-t-sm m-b-md" style="float:left">
              </div>

              <td>
                <input id="1" value="1" v-model="pickedwrite" type="radio">
                <label for="1">1</label>
              </td>

              <td>
                <input type="radio" id="2" value="2" v-model="pickedwrite">
                <label for="2">2</label>
              </td>

              <td>
                <input type="radio" id="3" value="3" v-model="pickedwrite">
                <label for="3">3</label>
              </td>
            </tr>
          </table>

          <table class="table table-hover">
            <tr>
              <b>
                <td style="float:left">Umiejętność</td>
              </b>
              <td>
                <div class="text-left m-t-sm m-b-md">
                  <select v-model="selectedskill" style="float:left;width: 160px">
                    <option v-for="skil in skills" :key="skil.Id">
                      {{ skil.skillName }}
                    </option>
                  </select>
                </div>
              </td>
            </tr>
          </table>
        </div>



        <table class="table table-hover">
          <tr>
            <b>
              <td style="float:left">Doświadczenie w latach</td>
            </b>
            <th>
              <div class="text-left m-t-sm m-b-md" style="float:left">
              </div>
              <input type="Exerience" class="form-control" id="Experience" placeholder="" style="width: 60px">
            </th>
          </tr>
        </table>

        <table class="table table-hover">
          <tr>
            <b>
              <td style="float:left">Stopień</td>
            </b>
            <div class="text-left m-t-sm m-b-md" style="float:left">
            </div>

            <td>
              <input id="1" value="1" v-model="pickedprof" type="radio">
              <label for="1">1</label>
            </td>

            <td>
              <input type="radio" id="2" value="2" v-model="pickedprof">
              <label for="2">2</label>
            </td>

            <td>
              <input type="radio" id="3" value="3" v-model="pickedprof">
              <label for="3">3</label>
            </td>

          </tr>
        </table>
        <div class="col-lg-4"></div>
        <button type="submit" class="btn btn-primary btn-outline">Zapisz zmiany</button>
        <router-link to="/employee">
          <button type="submit" class="btn btn-primary btn-outline">
            Wróć</button>
        </router-link>

      </div>
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
      languages: [],
      skills: [],
      projects: [],
      errors: [],
      pickedspeak: "",
      pickedwrite: "",
      pickedread: "",
      pickedprof: "",
      pickedrating: "",
      selectedskill: [],
      selectedlanguage: [],
      selectedproject: [],
      alert: ""
    };
  },
  // Fetches posts when the component is created.
  created() {
    axios
      .get("http://localhost:4444/api/languages/GetLanguages")
      .then(response => {
        this.languages = response.data;
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
    axios
      .get("http://localhost:4444/api/projects/GetProjects")
      .then(response => {
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
</style>
