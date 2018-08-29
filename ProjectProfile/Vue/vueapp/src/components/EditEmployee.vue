<template>
  <div class="addemployee">
    <bt/>
    <h1></h1>
    <h2></h2>

    <div class="col-lg-5"></div>
    <div class="col-lg-2">
      <div class="form-group">
        <label for="Name">Imie</label>
        <input type="Name" class="form-control" id="Name" placeholder="Imie">
      </div>

      <div class="form-group">
        <label for="LastName">Nazwisko</label>
        <input type="LastName" class="form-control" id="LastName" placeholder="Nazwisko">
      </div>

      <div class="form-group">
        <label for="Specialization">Specjalizacja</label>
        <input type="Specialization" class="form-control" id="Specialization" placeholder="Specjalizacja">
      </div>

      <div class="form-group">
        <label for="Rating">Ocena</label>
        <input type="Rating" class="form-control" id="Rating" placeholder="Ocena/Rating">
      </div>

      <div class="form-group">
        <label for="YearsOfWork">Kadencja</label>
        <input type="YearsOfWork" class="form-control" id="YearsOfWork" placeholder="Ilość przepracowanych lat">
      </div>
      <div class="col-lg-5"></div>

      <div class="form-group">
        <table class="table table-hover">
          <thead>
            <tr>
              <th>Projekt</th>
              <th>
                <div class="text-left m-t-sm m-b-md">
                  <select v-model="selectedsproject" style="float:left;width: 160px">
                    <option v-for="proj in projects" :key="proj.Id">
                      {{ proj.name }}
                    </option>
                  </select>
                </div>
              </th>
            </tr>
          </thead>
        </table>

        <div class="form-group">
          <table class="table table-hover">
            <thead>
              <tr>
                <th>Język</th>
                <th>
                  <div class="text-left m-t-sm m-b-md">
                    <select v-model="selectedlanguage" style="float:left;width: 160px">
                      <option v-for="lang in languages" :key="lang.Id">
                        {{ lang.languageName }}
                      </option>
                    </select>
                  </div>
                </th>
              </tr>
            </thead>
          </table>



          <table class="table table-hover">
            <thead>
              <tr>
                <th>Stopień w mowie</th>
                <th>
                  <div class="text-left m-t-sm m-b-md" style="float:left">
                  </div>
                  <input id="1" value="1" v-model="pickedspeak" type="radio">
                  <label for="1">1</label>
                  <input type="radio" id="2" value="2" v-model="pickedspeak">
                  <label for="2">2</label>
                  <input type="radio" id="3" value="3" v-model="pickedspeak">
                  <label for="3">3</label>
                </th>
              </tr>
            </thead>
          </table>


          <table class="table table-hover">
            <thead>
              <tr>
                <th>Stopień w czytaniu</th>
                <th>
                  <div class="text-left m-t-sm m-b-md" style="float:left">
                  </div>
                  <input id="1" value="1" v-model="pickedread" type="radio">
                  <label for="1">1</label>
                  <input type="radio" id="2" value="2" v-model="pickedread">
                  <label for="2">2</label>
                  <input type="radio" id="3" value="3" v-model="pickedread">
                  <label for="3">3</label>
                </th>
              </tr>
            </thead>
          </table>


          <table class="table table-hover">
            <thead>
              <tr>
                <th>Stopień w pisaniu</th>
                <th>
                  <div class="text-left m-t-sm m-b-md" style="float:left">
                  </div>
                  <input id="1" value="1" v-model="pickedwrite" type="radio">
                  <label for="1">1</label>
                  <input type="radio" id="2" value="2" v-model="pickedwrite">
                  <label for="2">2</label>
                  <input type="radio" id="3" value="3" v-model="pickedwrite">
                  <label for="3">3</label>
                </th>
              </tr>
            </thead>
          </table>


          <table class="table table-hover">
            <thead>
              <tr>
                <th>Umiejętność</th>
                <th>
                  <div class="text-left m-t-sm m-b-md">
                    <select v-model="selectedskill" style="float:left;width: 160px">
                      <option v-for="skil in skills" :key="skil.Id">
                        {{ skil.skillName }}
                      </option>
                    </select>
                  </div>
                </th>
              </tr>
            </thead>
          </table>
        </div>



        <table class="table table-hover">
          <thead>
            <tr>
              <th>Doświadczenie w latach</th>
              <th>
                <div class="text-left m-t-sm m-b-md" style="float:left">
                </div>
                <input type="Exerience" class="form-control" id="Experience" placeholder="" style="width: 60px">
              </th>
            </tr>
          </thead>
        </table>

        <table class="table table-hover">
          <thead>
            <tr>
              <th>Stopień</th>
              <th>
                <div class="text-left m-t-sm m-b-md" style="float:left">
                </div>
                <input type="radio" id="1" value="1" v-model="pickedprof">
                <label for="1">1</label>
                <input type="radio" id="2" value="2" v-model="pickedprof">
                <label for="2">2</label>
                <input type="radio" id="3" value="3" v-model="pickedprof">
                <label for="3">3</label>
                <input type="radio" id="4" value="4" v-model="pickedprof">
                <label for="4">4</label>
                <input type="radio" id="5" value="5" v-model="pickedprof">
                <label for="5">5</label>
              </th>
            </tr>
          </thead>
        </table>


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
