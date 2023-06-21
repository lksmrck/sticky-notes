import { UserType } from "../types";
import {
  createContext,
  ReactNode,
  useState,
  useEffect,
  FC,
  useContext,
  Dispatch,
  SetStateAction,
} from "react";
import { getLocalStorage } from "../utils/getLocalStorage";

interface AuthContextInterface {
  currentUser: /* User | null; */ any;
  setCurrentUser: /* Dispatch<SetStateAction<User | null>>; */ any;
  isLoading: boolean;
}

export const AuthContext = createContext({} as AuthContextInterface);

export const AuthContextProvider: FC<{
  children: ReactNode;
}> = ({ children }) => {
  const [currentUser, setCurrentUser] = useState<UserType | null>(
    getLocalStorage("user") || null
  );
  const [isLoading, setIsLoading] = useState(true);

  useEffect(() => {
    localStorage.setItem("user", JSON.stringify(currentUser));
    console.log(currentUser);
  }, [currentUser]);

  return (
    <AuthContext.Provider
      value={{
        currentUser,
        setCurrentUser,
        isLoading,
      }}
    >
      {children}
    </AuthContext.Provider>
  );
};
const useAuth = () => {
  return useContext(AuthContext);
};

export default useAuth;
