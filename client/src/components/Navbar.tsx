/* 
import { Button } from "@mui/material"; */
import { useNavigate } from "react-router-dom";
import Button from "./Button";
import useAuth from "../context/AuthContext";

const Navbar = () => {
  const navigate = useNavigate();

  const { currentUser, setCurrentUser } = useAuth();

  const handleLogout = () => {
    localStorage.removeItem("user");
    navigate("/landing");
    /* setCurrentUser(null); */
  };

  return (
    <div className="bg-amber-200">
      <div className="w-full flex justify-between p-4">
        <h1
          className="m-1 cursor-pointer text-3xl font-bold text-white"
          onClick={() => navigate("/notes")}
        >
          NotesApp
        </h1>

        <div className="flex [&>*]:m-1">
          {!currentUser && (
            <Button
              red={true}
              onClick={() => navigate("/login")}
              text={"Sign In"}
            />
          )}

          {currentUser && (
            <div className="flex">
              <Button
                blue={true}
                onClick={() => navigate("/add-note")}
                text={"Add Note"}
              />
              <Button red={true} onClick={handleLogout} text={"Logout"} />
            </div>
          )}
        </div>
      </div>
    </div>
  );
};

export default Navbar;
