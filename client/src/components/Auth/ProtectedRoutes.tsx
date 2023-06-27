import { useLocation, Navigate, Outlet } from "react-router-dom";
import useAuth from "../../context/AuthContext";
import { FC } from "react";

const ProtectedRoutes: FC = ({}) => {
  const { currentUser } = useAuth();
  const location = useLocation();
  console.log(currentUser);

  return currentUser ? <Outlet /> : <Navigate to="/login" />;
};
export default ProtectedRoutes;
