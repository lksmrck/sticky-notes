import { useState } from "react";
import Input from "../Input";
import Button from "../Button";

const Login = () => {
  const [formData, setFormData] = useState(
    {} as { username: string; password: string }
  );

  const inputChangeHandler = (e: React.ChangeEvent<HTMLInputElement>) => {};

  return (
    <div className="w-full h-full flex justify-center items-center">
      <div className=" rounded-lg bg-white w-96 h-96 flex flex-col justify-center items-center">
        <form className="flex flex-col justify-center items-center">
          <Input
            value={formData.username}
            onChange={inputChangeHandler}
            name="username"
          />
          <Input
            value={formData.password}
            onChange={inputChangeHandler}
            name="password"
          />
          <Button />
        </form>
      </div>
    </div>
  );
};

export default Login;
