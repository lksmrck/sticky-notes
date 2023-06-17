import React from "react";
import logo from "./logo.svg";
import "./App.css";
import Navbar from "./components/Navbar";
import Note from "./components/Note/Note";
import NoteList from "./components/Note/NoteList";
import MainPage from "./pages/MainPage";
import { useEffect } from "react";
import { Route, Routes } from "react-router-dom";
import AddNotePage from "./pages/AddNotePage";
import Login from "./components/Auth/Login";
import Register from "./components/Auth/Register";

function App() {
  return (
    <div className="App">
      <Navbar />
      <div className=" w-full h-screen bg-pink-300">
        <Routes>
          <Route path="/" element={<MainPage />} />
          <Route path="/add-note" element={<AddNotePage />} />
          <Route path="/login" element={<Login />} />
          <Route path="/register" element={<Register />} />
        </Routes>
      </div>
    </div>
  );
}

export default App;
