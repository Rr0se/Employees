<template>
<div class="cardclass">
    <h2>Karta Pracownika</h2>
    <br/><br/><br/>
    <div class="employee" style="float: left;">
     <tr v-for="emp in employees" :key="emp.Id">
        {{emp.name}}
        </tr>
    </div>
</div>
</template>

<script>
// https://alligator.io/vuejs/rest-api-axios/
// Access-Control-Allow-Origin: *

import axios from 'axios';

export default {
 data() {
   return {
     employees: [],
     errors: []
   }
 },

 // Fetches posts when the component is created.
 created() {
   axios.get(`http://localhost:56070/api/employees/GetEmployee?id=746916C8-001E-4364-6FC0-08D5FC3FB123`)
   .then(response => {
     console.log('asdaqwe')
     // JSON responses are automatically parsed.
       this.employees = response.data;
     })
     .catch(e => {
       this.errors.push(e);
     });
 },
};

</script>


<style scoped>
h1, h2 {
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
