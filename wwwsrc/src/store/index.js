import Vue from "vue";
import Vuex from "vuex";
import Axios from "axios";
import router from "../router";

Vue.use(Vuex);

let baseUrl = location.host.includes("localhost")
  ? "https://localhost:5001/"
  : "/";

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
});

export default new Vuex.Store({
  state: {
    rooms: [],
    activeRoom:{}
  },
  mutations: {
    setRooms(state, rooms) {
      state.rooms = rooms
    },
    addRoom(state, newRoom) {
      state.rooms.push(newRoom)
    },
  },
  actions: {
    setBearer({}, bearer) {
      api.defaults.headers.authorization = bearer;
    },
    resetBearer() {
      api.defaults.headers.authorization = "";
    },
    async getMyRooms({ commit, dispatch }) {
      let res = await api.get("rooms")
      commit("setRooms", res.data)
    },
    async addRoom({commit, dispatch}, newRoom){
      try {
        let res = await api.post("rooms", newRoom )
        commit("addRoom", res.data)
      } catch (error) {
        console.log(error);
      }
    },
  }
});
