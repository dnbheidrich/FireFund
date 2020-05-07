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
    activeRoom:{},
    categories: [],
    activeCategory:{}
  },
  mutations: {
    setRooms(state, rooms) {
      state.rooms = rooms
    },
    setActiveRoom(state, room) {
      state.activeRoom = room;
    },
    addRoom(state, newRoom) {
      state.rooms.push(newRoom)
    },
    setCategories(state, rooms) {
      state.categories = rooms
    },
    setActiveCategory(state, room) {
      state.activeCategory = room;
    },
    addCategory(state, newCategories) {
      state.rooms.push(newCategories)
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
     async getRoomById({ commit, dispatch }, id) {
      try {
        let res = await api.get("rooms/" + id);
        commit("setActiveRoom", res.data); 
      } catch (error) {
        console.error(error);
        // router.push({ name: "Home" });
      }
    },
    async getCategoriesByRoomId({ commit, dispatch }, id) {
      try {
        let res = await api.get("rooms/" + id + "/categories");
        commit("setCategories", res.data); 
      } catch (error) {
        console.error(error);
        // router.push({ name: "Home" });
      }
    },
    setActiveRoom({ commit }, room) {
      commit("setActiveRoom", room);
    },
    async addRoom({commit, dispatch}, newRoom){
      try {
        let res = await api.post("rooms", newRoom )
        commit("addRoom", res.data)
      } catch (error) {
        console.log(error);
      }
    },
    async getMyCategories({ commit, dispatch }) {
      let res = await api.get("categories")
      commit("setCategories", res.data)
    },
     async getCategoryById({ commit, dispatch }, id) {
      try {
        let res = await api.get("categories/" + id);
        commit("setCategories", res.data); 
      } catch (error) {
        console.error(error);
        // router.push({ name: "Home" });
      }
    },
    setActiveCategory({ commit }, categories) {
      commit("setActiveCategory", categories);
    },
    async addCategory({commit, dispatch}, newCategory){
      try {
        let res = await api.post("categories", newCategory )
        commit("addCategory", res.data)
      } catch (error) {
        console.log(error);
      }
    },
  }
});


