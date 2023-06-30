import React from "react";
import logo from "./logo.svg";
import "./App.css";
import Navbar from "./components/Navbar";
import Note from "./components/Note/Note";
import NoteList from "./components/Note/NoteList";
import NotesPage from "./pages/NotesPage";
import { useEffect } from "react";
import { Route, Routes } from "react-router-dom";
import AddNotePage from "./pages/AddNotePage";
import Login from "./components/Auth/Login";
import Register from "./components/Auth/Register";
import useAuth from "./context/AuthContext";
import ProtectedRoutes from "./components/Auth/ProtectedRoutes";
import ErrorPage from "./pages/ErrorPage";
import Landing from "./pages/Landing";

function App() {
  const { currentUser } = useAuth();
  return (
    <div className="App">
      <Navbar />
      <div className=" w-full h-screen bg-amber-100">
        <Routes>
          <Route path="/landing" element={<Landing />} />
          <Route element={<ProtectedRoutes />}>
            <Route path="/notes" element={<NotesPage />} />
            <Route path="/add-note" element={<AddNotePage />} />
          </Route>
          <Route path="/login" element={<Login />} />
          <Route path="/register" element={<Register />} />
          <Route path="/error" element={<ErrorPage />} />
        </Routes>
      </div>
    </div>
  );
}

export default App;
