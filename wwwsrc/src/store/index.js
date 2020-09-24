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
    activeCategory:{},
    items:{},
    activeItem:{}
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
    setItems(state, items) {
      state.items = items
    },
    setActiveItem(state, item) {
      state.activeItem = item;
    },
    addItem(state, newItem) {
      state.items.push(newItem)
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
    async deleteRoomById({ commit, dispatch },  id) {
      try {
        let res = await api.delete("rooms/" + id)
        dispatch("getMyRooms")
      } catch (error) {
        console.error(error);
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
    async deleteCategoryById({ commit, dispatch },  {id , roomId}) {
      try {
        let res = await api.delete("categories/" + id)
        dispatch("getCategoriesByRoomId", roomId)
      } catch (error) {
        console.error(error);
      }
    },
    // Items
    async getItemsByCategoriesId({ commit, dispatch }, id) {
      try {
        let res = await api.get("categories/" + id + "/items");
        commit("setItems", res.data); 
      } catch (error) {
        console.error(error);
        // router.push({ name: "Home" });
      }
    },
    async getMyItems({ commit, dispatch }) {
      let res = await api.get("items")
      commit("setItems", res.data)
    },
     async getItemById({ commit, dispatch }, id) {
      try {
        let res = await api.get("items/" + id);
        commit("setItems", res.data); 
      } catch (error) {
        console.error(error);
        // router.push({ name: "Home" });
      }
    },
    setActiveItem({ commit }, items) {
      commit("setActiveItem", items);
    },
    async addItem({commit, dispatch}, newItem){
      try {
        let res = await api.post("items", newItem )
        commit("addItem", res.data)
      } catch (error) {
        console.log(error);
      }
    },
    async deleteItemById({ commit, dispatch },  {id , roomId}) {
      try {
        let res = await api.delete("items/" + id)
        dispatch("getItemsByRoomId", roomId)
      } catch (error) {
        console.error(error);
      }
    },
  }
});


