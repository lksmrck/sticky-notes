import React from "react";
import logo from "./logo.svg";
import "./App.css";
import Navbar from "./components/Navbar";
import Note from "./components/Note/Note";
import NoteList from "./components/Note/NoteList";
import MainPage from "./pages/MainPage";

function App() {
  return (
    <div className="App">
      <Navbar />
      <div className=" w-full h-screen bg-pink-300">
        <MainPage />
      </div>
    </div>
  );
}

export default App;
