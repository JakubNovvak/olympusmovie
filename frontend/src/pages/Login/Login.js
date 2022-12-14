import * as React from "react";
import styles from "./Login.module.css";
import Box from "@mui/material/Box";
import { styled } from "@mui/material/styles";
import CardMedia from "@mui/material/CardMedia";
import IconButton from "@mui/material/IconButton";
import Input from "@mui/material/Input";
import InputLabel from "@mui/material/InputLabel";
import InputAdornment from "@mui/material/InputAdornment";
import FormHelperText from "@mui/material/FormHelperText";
import FormControl from "@mui/material/FormControl";
import TextField from "@mui/material/TextField";
import Visibility from "@mui/icons-material/Visibility";
import VisibilityOff from "@mui/icons-material/VisibilityOff";
import Button from "@mui/material/Button";
import Typography from "@mui/material/Typography";
import Checkbox from "@mui/material/Checkbox";
import logo from "../../assets/logo.svg";
import Divider from "@mui/material/Divider";
import { Link } from "react-router-dom";
import { useFormik } from "formik";
import { useNavigate } from "react-router-dom";

import Stack from "@mui/material/Stack";
import Snackbar from "@mui/material/Snackbar";
import MuiAlert from "@mui/material/Alert";
import useAuth from "../../hooks/useAuth";
import { useState } from "react";
import axios from "axios";

const PasswordEssentialsContainer = styled(Box)(({ theme }) => ({
  display: "flex",
  justifyContent: "space-around",
  alignItems: "center",
  width: "82%",
  paddingBottom: "30px",
}));

const RememberMeContainer = styled(Box)(({ theme }) => ({
  display: "flex",
  alignItems: "center",
}));

const RememberMeText = styled(Typography)(({ theme }) => ({
  display: "flex",
  fontSize: "15px",
  fontWeight: "500",
  color: "black",
}));

const LogInTextContainer = styled(Typography)(({ theme }) => ({
  position: "relative",
  //bottom: "1%",
  paddingBottom: "20px",
  fontWeight: "600",
}));

const ForgotPasswordText = styled(Typography)(({ theme }) => ({
  display: "flex",
  // right: "17%",
  fontSize: "15px",
  fontWeight: "500",
  color: "#1d77b8",
}));

const RegisterText = styled(Typography)(({ theme }) => ({
  position: "relative",
  paddingTop: "50px",
  paddingBottom: "20px",
  fontSize: "15px",
  fontWeight: "800",
  color: "#1d77b8",
}));

const Container = styled("div")(({ theme }) => ({
  display: "flex",
  alignItems: "center",
  justifyContent: "center",
  minHeight: "calc(100vh - 233px)",
}));

const LoginBoxContainer = styled(Box)(({ theme }) => ({
  display: "flex",
  alignItems: "center",
  justifyContent: "center",
  flexDirection: "column",
  backgroundColor: "white",
  boxShadow: "10px 10px 20px 3px rgba(0, 0, 0, 0.6)",
  borderRadius: "20px",
  width: "500px",
  height: "500px",
}));

const ImageContainer = styled(CardMedia)(({ theme }) => ({
  position: "relative",
  bottom: "2%",
  width: "60px",
}));

const TextFieldContainer = styled("div")(({ theme }) => ({
  textAlign: "center",
  padding: "10px",
}));

const Alert = React.forwardRef(function Alert(props, ref) {
  return <MuiAlert elevation={6} ref={ref} variant="filled" {...props} />;
});

const Login = (props) => {
  const label = { inputProps: { "aria-label": "Checkbox demo" } };
  const [open, setOpen] = React.useState(false);
  const [wasSuccessful, setSucessState] = React.useState(true);
  const [loadingButton, setloadingButton] = React.useState(false);
  const { setAuth } = useAuth();
  const navigate = useNavigate();

  const handleClose = (event, reason) => {
    setOpen(false);
    if (reason === "clickaway") {
      return;
    }
  };

/*    const onSubmit = (values, actions) => {
        console.log(values);
        console.log(actions);
        setloadingButton(true);

        axios
            .post("/api/account/login", JSON.stringify(values), {
                headers: {
                    "Content-Type": "application/json",
                },
            })
            .then(
                (response) => {
                    console.log(JSON.stringify(response?.data));
                    const accessToken = response?.data?.accessToken;
                    const refreshToken = response?.data?.refreshToken;
                    const username = values.username;

                    axios.get(`api/user?username=${username}`).then(
                        (response) => {
                            const userId = response?.data;
                            console.log({ userId, username, accessToken, refreshToken });
                            setAuth({ userId, username, accessToken, refreshToken });
                            props.setLoggedIn(true);
                            setSucessState(true);
                            setOpen(true);
                            console.log("Zalogowano");
                            navigate("/");
                        },
                        (error) => { }
                    );
                },
                (error) => {
                    console.log(error);
                    props.setLoggedIn(false);
                    setSucessState(false);
                    setOpen(true);
                    setloadingButton(false);
                }
            );
    };*/

  const onSubmit = (values, actions) => {
    console.log(values);
    console.log(actions);
    setloadingButton(true);

    axios
      .post("/api/account/login", JSON.stringify(values), {
        headers: {
          "Content-Type": "application/json",
        },
      })
      .then(
        (response) => {
          console.log(JSON.stringify(response?.data));
          const accessToken = response?.data?.accessToken;
          const refreshToken = response?.data?.refreshToken;
          const username = values.username;

          axios.get(`api/user?username=${username}`).then(
            (response) => {
              const userId = response?.data;
              console.log({ userId, username, accessToken, refreshToken });
              setAuth({ userId, username, accessToken, refreshToken });
              props.setLoggedIn(true);
              setSucessState(true);
              setOpen(true);
              console.log("Zalogowano");
              navigate("/");
            },
            (error) => {}
          );
        },
        (error) => {
          console.log(error);
          props.setLoggedIn(false);
          setSucessState(false);
          setOpen(true);
          setloadingButton(false);
        }
      );
  };

  const formik = useFormik({
    initialValues: {
      username: "",
      password: "",
    },
    validationSchema: null,
    onSubmit,
  });

  const [values, setValues] = React.useState({
    amount: "",
    password: "",
    weight: "",
    weightRange: "",
    showPassword: false,
  });

  const handleChange = (prop) => (event) => {
    setValues({ ...values, [prop]: event.target.value });
  };

  const handleClickShowPassword = () => {
    setValues({
      ...values,
      showPassword: !values.showPassword,
    });
  };

  const handleMouseDownPassword = (event) => {
    event.preventDefault();
  };

  return (
    <>
      <Container>
        <Snackbar open={open} autoHideDuration={6000} onClose={handleClose}>
          <Alert
            onClose={handleClose}
            onClick={handleClose}
            severity={wasSuccessful ? "success" : "error"}
            sx={{ width: "100%" }}
          >
            {wasSuccessful
              ? "Logowanie powiod??o si??"
              : "Logowanie nie powiod??o si??"}
          </Alert>
        </Snackbar>

        <form onSubmit={formik.handleSubmit}>
          <LoginBoxContainer>
            <ImageContainer component="img" image={logo} alt="Olympus Movie" />

            <LogInTextContainer variant="h6">Zaloguj si??</LogInTextContainer>

            <Divider sx={{ width: "100%" }} />

            <TextFieldContainer>
              <FormControl
                size="small"
                variant="standard"
                error={!wasSuccessful ? true : false}
                style={{ minWidth: "320px" }}
              >
                <InputLabel
                  htmlFor="standard-adornment-password"
                  sx={{ fontSize: "15px" }}
                >
                  Nazwa u??ytkownika
                </InputLabel>
                <Input
                  value={formik.values.username}
                  onChange={formik.handleChange}
                  onBlur={formik.handleBlur}
                  id="username"
                  sx={{ fontSize: "15px" }}
                />
              </FormControl>
            </TextFieldContainer>

            <TextFieldContainer>
              <FormControl
                size="small"
                variant="standard"
                error={!wasSuccessful ? true : false}
                style={{ minWidth: "320px" }}
              >
                <InputLabel
                  htmlFor="standard-adornment-password"
                  sx={{ fontSize: "15px" }}
                >
                  Has??o
                </InputLabel>
                <Input
                  value={formik.values.password}
                  onChange={formik.handleChange}
                  onBlur={formik.handleBlur}
                  id="password"
                  sx={{ fontSize: "15px" }}
                  type={values.showPassword ? "text" : "password"}
                  endAdornment={
                    <InputAdornment position="end">
                      <IconButton
                        aria-label="toggle password visibility"
                        onClick={handleClickShowPassword}
                        onMouseDown={handleMouseDownPassword}
                      >
                        {values.showPassword ? (
                          <VisibilityOff />
                        ) : (
                          <Visibility />
                        )}
                      </IconButton>
                    </InputAdornment>
                  }
                />
              </FormControl>
            </TextFieldContainer>

            {/*<PasswordEssentialsContainer>
              <RememberMeContainer>
                <Checkbox
                  {...label}
                  defaultChecked
                  sx={{ display: "flex" }}
                ></Checkbox>
                <RememberMeText>Zapami??taj mnie</RememberMeText>
              </RememberMeContainer>

              <ForgotPasswordText variant="h7">
                Zapomnia??e?? has??a?
              </ForgotPasswordText>
            </PasswordEssentialsContainer>*/}

            <Button
              type="submit"
              variant="contained"
              disabled={!loadingButton ? false : true}
              sx={{
                fontSize: "14px",
                backgroundColor: "#201c1c",
                borderRadius: "15px",
                  width: "180px",
                marginTop: "20px"
              }}
            >
              {!loadingButton ? "Zaloguj si??" : "??adowanie"}
            </Button>

            <RegisterText variant="h7">
              Nie masz jeszcze konta? &nbsp;
              <Link to="/Register">Za?????? je tutaj!</Link>
            </RegisterText>
          </LoginBoxContainer>
        </form>
      </Container>
    </>

    /* <>
      <div className={styles.Login}>
        <div className={styles.Box}>
          <h2>Zaloguj si??</h2>

          <input
            type="text"
            className={styles.NoOutline}
            required
            placeholder="Nazwa u??ytkownika"
          />
          <br />
          <input
            type="password"
            className={styles.NoOutline}
            required
            placeholder="Has??o"
          />

          <div className={styles.Forgot}>Zapomnia??em has??a</div>

          <button className={styles.SubmitButton}>Zaloguj si??</button>

          <div className={styles.BottomInfo}>
            Nie masz jeszcze konta?&nbsp;
            <a
              href="http://localhost:3000/Register"
              className={styles.Register}
            >
              Za?????? je tutaj!
            </a>
          </div>
        </div>
      </div>
    </>*/
  );
};

export default Login;
