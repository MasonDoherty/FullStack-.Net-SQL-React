import React from "react";
import { Route, Routes } from "react-router-dom";
import NavMenu from "./components/NavMenu";
import "./custom.css";
import Home from "./components/Home";

const App = () => {
  return (
    <>
      <NavMenu />
      <Routes>
        <Route path="/Home" element={<Home />} />
      </Routes>
    </>
  );
};

export default App;
