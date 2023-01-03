import axios from "axios";
import useAuth from "./useAuth";

const useRefreshToken = () => {
  const { setAuth } = useAuth();

  const refresh = async () => {
    const response = await axios.get("/RefreshToken", {
      withCredentials: true,
    });

    setAuth((prev) => {
      console.log(JSON.stringify(prev));
      console.log("Actual accessToken: " + response.data.accessToken);
      console.log("Actual refreshToken: " + response.data.refreshToken);
      return {
        ...prev,
        accessToken: response.data.accessToken,
        refreshToken: response.data.refreshToken,
      };
    });

    return refresh;
  };
};

export default useRefreshToken;
