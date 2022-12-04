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


const LogInTextContainer = styled(Typography)(({ theme }) => ({
    position: "relative",
    bottom: "1%",
    paddingBottom: "20px",
    fontWeight: "600"
})); 

const ForgotPasswordText = styled(Typography)(({ theme }) => ({
    position: "relative",
    right: "17%",
    paddingTop: "5px",
    paddingBottom: "30px",
    fontSize: "15px",
    fontWeight: "500",
    color: "#2596be"
})); 

const RegisterText = styled(Typography)(({ theme }) => ({
    position: "relative",
    paddingTop: "50px",
    paddingBottom: "20px",
    fontSize: "15px",
    fontWeight: "500",
    color: "black"
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
    borderRadius: "20px",
    width: "400px",
    height: "470px"
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

const Login = () => {

    const label = { inputProps: { 'aria-label': 'Checkbox demo' } };
    //<Checkbox {...label} defaultChecked />

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

                <LoginBoxContainer>

                    <ImageContainer
                        component="img"
                        image={logo}
                        alt="Olympus Movie"
                    />

                    <LogInTextContainer variant="h6">Zaloguj się</LogInTextContainer>

                    <TextFieldContainer>
                        <FormControl size="small" variant="standard" style={{ minWidth: "270px" }}>
                            <InputLabel htmlFor="standard-adornment-password" sx={{ fontSize: "15px" }}>Nazwa użytkownika</InputLabel>
                            <Input sx={{ fontSize: "15px" }} />
                        </FormControl>
                    </TextFieldContainer>
                    
                    <TextFieldContainer>
                        <FormControl size="small" variant="standard" style={{ minWidth: "270px" }}>
                            <InputLabel htmlFor="standard-adornment-password" sx={{ fontSize: "15px" }}>Hasło</InputLabel>
                            <Input
                            sx={{ fontSize: "15px" }}
                            id="standard-adornment-password"
                            type={values.showPassword ? 'text' : 'password'}
                            value={values.password}
                            onChange={handleChange('password')}
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

                    <ForgotPasswordText variant="h7" >Zapomniałeś hasła?</ForgotPasswordText>
                    Tutaj czekboks
                    <Button variant="contained" sx={{ fontSize: "14px", backgroundColor: "#201c1c", borderRadius: "15px" }}>Zaloguj się</Button>

                    <RegisterText variant="h7" >Nie masz jeszcze konta? Załóż je tutaj!</RegisterText>

                </LoginBoxContainer>

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
