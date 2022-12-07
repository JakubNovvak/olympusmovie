import * as React from 'react';
import styles from "./Login.module.css";
import Box from "@mui/material/Box";
import { styled } from "@mui/material/styles";
import CardMedia from '@mui/material/CardMedia';
import IconButton from '@mui/material/IconButton';
import Input from '@mui/material/Input';
import InputLabel from '@mui/material/InputLabel';
import InputAdornment from '@mui/material/InputAdornment';
import FormHelperText from '@mui/material/FormHelperText';
import FormControl from '@mui/material/FormControl';
import TextField from '@mui/material/TextField';
import Visibility from '@mui/icons-material/Visibility';
import VisibilityOff from '@mui/icons-material/VisibilityOff';
import Button from "@mui/material/Button";
import Typography from "@mui/material/Typography";
import Checkbox from '@mui/material/Checkbox';
import logo from "../../assets/logo.svg";
import Divider from '@mui/material/Divider';
import { Link } from "react-router-dom";
import { useFormik } from "formik";

const PasswordEssentialsContainer = styled(Box)(({ theme }) => ({
    display: "flex",
    justifyContent: "space-around",
    alignItems: "center",
    width: "82%",
    paddingBottom: "30px"
})); 

const RememberMeContainer = styled(Box)(({ theme }) => ({
    display: "flex",
    alignItems: "center",
    
}));

const RememberMeText = styled(Typography)(({ theme }) => ({
    display: "flex",
    fontSize: "15px",
    fontWeight: "500",
    color: "black"
})); 

const LogInTextContainer = styled(Typography)(({ theme }) => ({
    position: "relative",
    //bottom: "1%",
    paddingBottom: "20px",
    fontWeight: "600"
})); 

const ForgotPasswordText = styled(Typography)(({ theme }) => ({
    display: "flex",
   // right: "17%",
    fontSize: "15px",
    fontWeight: "500",
    color: "#1d77b8"
})); 

const RegisterText = styled(Typography)(({ theme }) => ({
    position: "relative",
    paddingTop: "50px",
    paddingBottom: "20px",
    fontSize: "15px",
    fontWeight: "800",
    color: "#1d77b8"
})); 

const Container = styled("div")(({ theme }) => ({
    display: "flex",
    alignItems: "center",
    justifyContent: "center",
    minHeight: "calc(100vh - 233px)"
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
    height: "500px"
}));

const ImageContainer = styled(CardMedia)(({ theme }) => ({
    position: "relative",
    bottom: "2%",
    width: "60px"    
}));

const TextFieldContainer = styled("div")(({ theme }) => ({
    textAlign: "center",
    padding: "10px"
}));

const Login = (props) => {

    const label = { inputProps: { 'aria-label': 'Checkbox demo' } };

    const onSubmit = (values, actions) => {
        console.log(values);
        console.log(actions);

        fetch(`/api/account/login`, {
            method: "post", body: JSON.stringify(values), headers: {
                'Content-Type': 'application/json',
            }
        })
            .then((response) => {
                if (response.status === 200) {
                    props.setLoggedIn(true);
                    console.log("Zalogowano");
                }
                console.log("Response: " + response);
            });

    }

    const formik = useFormik({
        initialValues: {
            username: "",
            password: "",
        },
        validationSchema: null,
        onSubmit,
    });


    const [values, setValues] = React.useState({
        amount: '',
        password: '',
        weight: '',
        weightRange: '',
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
                <form onSubmit={formik.handleSubmit}>
                <LoginBoxContainer>

                    <ImageContainer
                        component="img"
                        image={logo}
                        alt="Olympus Movie"
                    />

                    <LogInTextContainer variant="h6">Zaloguj się</LogInTextContainer>

                    <Divider sx={{width: "100%"}} />

                    <TextFieldContainer>
                        <FormControl size="small" variant="standard" style={{ minWidth: "320px" }}>
                            <InputLabel htmlFor="standard-adornment-password" sx={{ fontSize: "15px" }}>Nazwa użytkownika</InputLabel>
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
                        <FormControl size="small" variant="standard" style={{ minWidth: "320px" }}>
                            <InputLabel htmlFor="standard-adornment-password" sx={{ fontSize: "15px" }}>Hasło</InputLabel>
                            <Input
                            value={formik.values.password}
                            onChange={formik.handleChange}
                            onBlur={formik.handleBlur}
                            id="password"
                            sx={{ fontSize: "15px" }}

                            type={values.showPassword ? 'text' : 'password'}
                            endAdornment={
                                <InputAdornment position="end">
                                    <IconButton
                                        aria-label="toggle password visibility"
                                        onClick={handleClickShowPassword}
                                        onMouseDown={handleMouseDownPassword}
                                    >
                                        {values.showPassword ? <VisibilityOff /> : <Visibility />}
                                    </IconButton>
                                </InputAdornment>
                            }
                            />
                        </FormControl>
                    </TextFieldContainer>

                    <PasswordEssentialsContainer>

                        <RememberMeContainer>
                            <Checkbox {...label} defaultChecked sx={{ display: "flex" }} ></ Checkbox>
                            <RememberMeText>Zapamiętaj mnie</RememberMeText>
                        </RememberMeContainer>

                        <ForgotPasswordText variant="h7" >Zapomniałeś hasła?</ForgotPasswordText>

                    </PasswordEssentialsContainer>

                    <Button type="submit" variant="contained" sx={{ fontSize: "14px", backgroundColor: "#201c1c", borderRadius: "15px", width:"180px" }}>Zaloguj się</Button>

                    <RegisterText variant="h7" >Nie masz jeszcze konta?
                        &nbsp;
                        <Link to="/Register" >Załóż je tutaj!</Link>
                    </RegisterText>

                </LoginBoxContainer>

                </form>
            </Container>

        </>





   /* <>
      <div className={styles.Login}>
        <div className={styles.Box}>
          <h2>Zaloguj się</h2>

          <input
            type="text"
            className={styles.NoOutline}
            required
            placeholder="Nazwa użytkownika"
          />
          <br />
          <input
            type="password"
            className={styles.NoOutline}
            required
            placeholder="Hasło"
          />

          <div className={styles.Forgot}>Zapomniałem hasła</div>

          <button className={styles.SubmitButton}>Zaloguj się</button>

          <div className={styles.BottomInfo}>
            Nie masz jeszcze konta?&nbsp;
            <a
              href="http://localhost:3000/Register"
              className={styles.Register}
            >
              Załóż je tutaj!
            </a>
          </div>
        </div>
      </div>
    </>*/
  );
};

export default Login;
