import React from "react";
import logo from "./logo.svg";
import "./App.css";
import Navbar from "./components/Navbar";
import Note from "./components/Note/Note";
import NoteList from "./components/Note/NoteList";
import MainPage from "./pages/MainPage";
import { useEffect } from "react";

function App() {
  useEffect(() => {
    const fetchData = async () => {
      const response = await fetch("https://localhost:7280/weatherforecast");
      const data = await response.json();
      console.log(data);
    };

    fetchData();
  }, []);

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
