import { useState } from "react";
import Input from "../Input";
import Button from "../Button";

const Register = () => {
  const [formData, setFormData] = useState(
    {} as { username: string; password: string }
  );

  const inputChangeHandler = (e: React.ChangeEvent<HTMLInputElement>) => {};

  return (
    <div className="w-full h-full flex justify-center items-center">
      <div className=" rounded-lg bg-white w-52 h-52">
        <form>
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

export default Register;
