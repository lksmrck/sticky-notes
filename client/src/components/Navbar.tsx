/* 
import { Button } from "@mui/material"; */
import { useNavigate } from "react-router-dom";
import Button from "./Button";
import useAuth from "../context/AuthContext";

const Navbar = () => {
  const navigate = useNavigate();

  const { currentUser } = useAuth();

  return (
    <div>
      <div className="w-full flex justify-between p-4">
        <h1>Ahoj</h1>
        {/*  <Button className="rounded-full border border-blue-950 bg-blue-950 py-1.5 px-5 text-white transition-all hover:bg-slate-900 text-center text-sm  flex items-center justify-center">
            Sign Out
          </Button> */}
        <div className="flex [&>*]:m-1">
          {!currentUser && (
            <Button
              red={true}
              onClick={() => navigate("/login")}
              text={"Sign In"}
            />
          )}

          <Button
            blue={true}
            onClick={() => navigate("/add-note")}
            text={"Add Note"}
          />
        </div>
      </div>
    </div>
  );
};

export default Navbar;
