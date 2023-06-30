import { useState } from "react";
import Input from "../Input";
import Button from "../Button";
import { LoginUserType } from "../../types";
import { loginUser } from "../../api";
import useAuth from "../../context/AuthContext";
import { useNavigate } from "react-router-dom";

const Login = () => {
  const [formData, setFormData] = useState({} as LoginUserType);

  const { setCurrentUser } = useAuth();
  const navigate = useNavigate();

  const inputChangeHandler = (e: React.ChangeEvent<HTMLInputElement>) => {
    setFormData({ ...formData, [e.target.name]: e.target.value });
  };

  const loginButtonClickHandler = async (e: any) => {
    e.preventDefault();
    const loggedUser = await loginUser(formData);
    setCurrentUser(loggedUser);
    navigate("/notes");
  };

  return (
    <div className="w-full h-full flex justify-center items-center">
      <div className=" rounded-lg bg-white w-96 h-96 flex flex-col justify-center items-center">
        <form className="flex flex-col justify-center items-center">
          <Input
            value={formData.userName}
            onChange={inputChangeHandler}
            name="username"
          />
          <Input
            value={formData.password}
            onChange={inputChangeHandler}
            name="password"
          />
          <Button onClick={loginButtonClickHandler} text={"Login"} />
        </form>
      </div>
    </div>
  );
};

export default Login;
