<template>
  <div class="addproject">
    <bt/>
    <h1></h1>
    <h2></h2>
    <div class="col-lg-4"></div>
    <div class="col-lg-4">
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

        <button type="submit" class="btn btn-primary btn-outline">Dodaj projekt</button>
        <router-link to="/project">
          <button type="submit" class="btn btn-primary btn-outline">
            Wróć</button>
        </router-link>
      </form>
    </div>
    <div class="col-lg-4"></div>
  </div>
  
</template>

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
