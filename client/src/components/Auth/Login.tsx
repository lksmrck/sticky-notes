import { useState } from "react";
import Input from "../Input";
import Button from "../Button";
import { LoginUserType } from "../../types";
import { loginUser } from "../../api";

const Login = () => {
  const [formData, setFormData] = useState({} as LoginUserType);

  const inputChangeHandler = (e: React.ChangeEvent<HTMLInputElement>) => {
    setFormData({ ...formData, [e.target.name]: e.target.value });
  };

  const loginButtonClickHandler = (e: any) => {
    e.preventDefault();
    loginUser(formData);
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
