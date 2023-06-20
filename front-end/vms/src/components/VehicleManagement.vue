<template>
  <div>
    <h1>Vehicle Management</h1>

    <!-- Get all vehicles -->
    <button @click="getVehicles">Get Vehicles</button>
    <ul>
      <li v-for="vehicle in vehicles" :key="vehicle.id">
        {{ vehicle.brand }} - {{ vehicle.model }} ({{ vehicle.year }})
        <button @click="deleteVehicle(vehicle.id)">Delete</button>
        <button @click="selectVehicle(vehicle)">Update</button>
      </li>
    </ul>

    <!-- Create a new vehicle -->
    <h2>Create Vehicle</h2>
    <form @submit.prevent="createVehicle">
      <label for="brand">Brand:</label>
      <input type="text" id="brand" v-model="newVehicle.brand" required>

      <label for="model">Model:</label>
      <input type="text" id="model" v-model="newVehicle.model" required>

      <label for="year">Year:</label>
      <input type="number" id="year" v-model="newVehicle.year" required>

      <button type="submit">Create</button>
    </form>

    <!-- Update an existing vehicle -->
    <h2>Update Vehicle</h2>
    <form @submit.prevent="updateVehicle">
      <label for="updateBrand">Brand:</label>
      <input type="text" id="updateBrand" v-model="selectedVehicle.brand" required>

      <label for="updateModel">Model:</label>
      <input type="text" id="updateModel" v-model="selectedVehicle.model" required>

      <label for="updateYear">Year:</label>
      <input type="number" id="updateYear" v-model="selectedVehicle.year" required>

      <button type="submit">Update</button>
    </form>
  </div>
</template>

<script setup>
import axios from 'axios'
import { reactive, ref } from 'vue'

const vehicles = ref([])
const newVehicle = reactive({ brand: '', model: '', year: 0 })
const selectedVehicle = reactive({ id: 0, brand: '', model: '', year: 0 })

const getVehicles = async () => {
  try {
    const response = await axios.get('https://localhost:7113/api/vehicle')
    vehicles.value = response.data
  } catch (error) {
    console.error(error)
  }
}

const createVehicle = async () => {
  try {
    await axios.post('https://localhost:7113/api/vehicle', newVehicle)
    newVehicle.brand = ''
    newVehicle.model = ''
    newVehicle.year = 0
    await getVehicles() // Refresh the vehicle list
  } catch (error) {
    console.error(error)
  }
}

const updateVehicle = async () => {
  try {
    await axios.put(`https://localhost:7113/api/vehicle/${selectedVehicle.id}`, selectedVehicle)
    selectedVehicle.id = 0
    selectedVehicle.brand = ''
    selectedVehicle.model = ''
    selectedVehicle.year = 0
    await getVehicles() // Refresh the vehicle list
  } catch (error) {
    console.error(error)
  }
}

const deleteVehicle = async (id) => {
  try {
    await axios.delete(`https://localhost:7113/api/vehicle/${id}`)
    await getVehicles() // Refresh the vehicle list
  } catch (error) {
    console.error(error)
  }
}

const selectVehicle = (vehicle) => {
  selectedVehicle.id = vehicle.id
  selectedVehicle.brand = vehicle.brand
  selectedVehicle.model = vehicle.model
  selectedVehicle.year = vehicle.year
}
</script>
