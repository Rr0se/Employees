<template>
  <div class="cardclass">
    <div class="col-lg-4"></div>
    <div class="col-lg-4">
      <h2></h2>
      <br/>
      <br/>
      <br/>

      <div class="employee">

        <table>
          <thead>
            <tr>
              <td>
                <!--<td class="img" style="vertical-aligin:top">-->
                <img src="../assets/profile.jpg" style="widht:114px; height:95px">
              </td>
              <td text-name style="padding-top: 70px">
                <!--<div class="text-n" style="vertical- aligin:bottom">-->
                <h1>
                  <b>
                    <p>{{employee.profile.name}}</p>
                  </b>
                </h1>
              </td>
            </tr>
          </thead>
        </table>

        <tr>
          <td>
            <h2>
              <b>
                <p> {{employee.profile.specialization}}</p>
              </b>
            </h2>
          </td>
        </tr>


        <table class="table-level">
          <table class="table table-hover" border="1">
            <td v-for="numb in 5" class="box-level">
              <div v-if="numb <= employee.profile.rating" class="level">
              </div>
            </td>
            <h5>
              <p style="color:gray">Rating:{{employee.profile.rating}} / 5</p>
            </h5>
          </table>
        </table>

        <tr>
          <td>
            <h5>
              <p style="color:gray">Overall Tenure:{{employee.profile.overallTenure}}year</p>
            </h5>
          </td>
        </tr>


      </div>



      <table class="table table-hover" border="1" width="150px">
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

            <td class="table-level">
              <table class="table table-hover" border="1" style="margin-bottom: 0px">

                <td v-for="numb in 5" class="box-level">
                  <div v-if="numb <= skill.profficiency" class="level">
                  </div>
                </td>
              </table>
            </td>

          </tr>
        </tbody>
      </table>


      <table class="table table-hover">
        <tr>

          <td>
            <table class="table table-hover" border="1" style="margin-bottom:0;">
              <td class="box"></td>
            </table>
          </td>
          <td>Junior</td>

          <td>
            <table class="table table-hover" border="1" style="margin-bottom:0;">
              <td class="box"></td>
              <td class="box"></td>
            </table>
          </td>
          <td>Middle</td>

          <td>
            <table class="table table-hover" border="1" style="margin-bottom:0;">
              <td class="box"></td>
              <td class="box"></td>
              <td class="box"></td>
            </table>
          </td>
          <td>Proficient</td>

          <td>
            <table class="table table-hover" border="1" style="margin-bottom:0;">
              <td class="box"></td>
              <td class="box"></td>
              <td class="box"></td>
              <td class="box"></td>
            </table>
          </td>
          <td>Senior</td>

          <td>
            <table class="table table-hover" border="1" style="margin-bottom:0;">
              <td class="box"></td>
              <td class="box"></td>
              <td class="box"></td>
              <td class="box"></td>
              <td class="box"></td>
            </table>
          </td>
          <td>Expert</td>
        </tr>
      </table>

      <div v-for="p in employee.projects" :key="p.Id">
        <table class="table table-hover" border="1">
          <tr class="table-tittle">
            <td align="left" class="text-color" colspan="2">
              <h4> {{p.name}}</h4>
              <h4>{{p.title}}</h4>
            </td>

          </tr>
          <tr>
            <td align="left">
              Sector:

            </td>
            <td align="left">
              {{p.clientSector}}

            </td>
          </tr>
          <tr>
            <td align="left">
              Technologie:

            </td>
            <td align="left">
              <template v-for="t in p.technology">
                {{t.name}}
              </template>

            </td>
          </tr>
          <tr>
            <td align="left">
              Start:

            </td>
            <td align="left">
              {{p.startDate}}

            </td>
          </tr>
          <tr>
            <td align="left">
              Koniec:

            </td>
            <td align="left">
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

            <td class="table-level" align="left">
              <table class="table table-hover" border="1" style="margin-bottom: 0px">
                <td v-for="numb in 3" class="box-level">
                  <div v-if="numb <= lang.speaking" class="level">
                  </div>
                </td>
              </table>
            </td>

            <td class="table-level" align="left">
              <table class="table table-hover" border="1" style="margin-bottom: 0px">
                <td v-for="numb in 3" class="box-level">
                  <div v-if="numb <= lang.writing" class="level">
                  </div>
                </td>
              </table>
            </td>

            <td class="table-level" align="left">
              <table class="table table-hover" border="1" style="margin-bottom: 0px">
                <td v-for="numb in 3" class="box-level">
                  <div v-if="numb <= lang.reading" class="level">
                  </div>
                </td>
              </table>
            </td>
          </tr>
        </tbody>
      </table>

      <table class="table table-hover">
        <tr>

          <td>
            <table class="table table-hover" border="1" style="margin-bottom:0;">
              <td class="box"></td>
            </table>
          </td>
          <td>Basic</td>

          <td>
            <table class="table table-hover" border="1" style="margin-bottom:0;">
              <td class="box"></td>
              <td class="box"></td>
            </table>
          </td>
          <td>Good</td>

          <td>
            <table class="table table-hover" border="1" style="margin-bottom:0;">
              <td class="box"></td>
              <td class="box"></td>
              <td class="box"></td>
            </table>
          </td>
          <td>Fluent</td>
        </tr>
      </table>


      <div class="col-lg-4"></div>
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

.level {
  color: gray;
  background: #f64a35;
  width: 100%;
  height: 100%;
}

.box-level {
  width: 20px;
  height: 20px;
}

.box {
  width: 20px;
  height: 10px;
  background: #f64a35;
}

.text-name {
  padding-top: 70px;
}
</style>
