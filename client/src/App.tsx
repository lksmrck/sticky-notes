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
import useAuth from "./context/AuthContext";
import ProtectedRoutes from "./components/Auth/ProtectedRoutes";

function App() {
  const { currentUser } = useAuth();
  return (
    <div className="App">
      <Navbar />
      <div className=" w-full h-screen bg-amber-100">
        <Routes>
          <Route element={<ProtectedRoutes />}>
            <Route path="/" element={<MainPage />} />
            <Route path="/add-note" element={<AddNotePage />} />
          </Route>
          <Route path="/login" element={<Login />} />
          <Route path="/register" element={<Register />} />
        </Routes>
      </div>
    </div>
  );
}

export default App;
