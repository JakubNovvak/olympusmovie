import axios from "axios";
import useAuth from "./useAuth";

const useRefreshToken = () => {
  const { auth, setAuth } = useAuth();

  const refresh = () => {
    return axios
      .post(
        "/api/account/RefreshToken",
        JSON.stringify({
          accessToken: auth.accessToken,
          refreshToken: auth.refreshToken,
        }),
        {
          headers: { "Content-Type": "application/json" },
        }
      )
      .then(
        (response) => {
          setAuth((prev) => {
            return {
              ...prev,
              accessToken: response.data.accessToken,
              refreshToken: response.data.refreshToken,
            };
          });
          return response.data;
        },
        (error) => console.log(error)
      );
  };

  return refresh;
};

export default useRefreshToken;
