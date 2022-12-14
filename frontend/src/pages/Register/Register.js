import { React, createRef, useState, forwardRef, useEffect } from "react";
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
import CasinoIcon from "@mui/icons-material/Casino";
import logo from "../../assets/logo.svg";
import Divider from "@mui/material/Divider";
import { Link } from "react-router-dom";
import LockIcon from "@mui/icons-material/Lock";
import AssignmentIndIcon from "@mui/icons-material/AssignmentInd";
import EmailIcon from "@mui/icons-material/Email";
import FaceIcon from "@mui/icons-material/Face";
import dayjs, { Dayjs } from "dayjs";
import { AdapterDayjs } from "@mui/x-date-pickers/AdapterDayjs";
import { DesktopDatePicker } from "@mui/x-date-pickers/DesktopDatePicker";
import { LocalizationProvider } from "@mui/x-date-pickers/LocalizationProvider";
import CakeIcon from "@mui/icons-material/Cake";
import Slider from "react-slick";
import "slick-carousel/slick/slick.css";
import "slick-carousel/slick/slick-theme.css";
import { useFormik } from "formik";
import { BasicSchema } from "./BasicSchema";
import { useNavigate } from "react-router-dom";
import NicknameGenerator from "../../components/NicknameGenerator/NicknameGenerator";

import Stack from "@mui/material/Stack";
import Snackbar from "@mui/material/Snackbar";
import MuiAlert from "@mui/material/Alert";
import axios from "axios";

const Container = styled("div")(({ theme }) => ({
  display: "flex",
  alignItems: "center",
  justifyContent: "center",
  padding: "5%",
  minHeight: "calc(100vh - 233px)",
}));

const RegisterBoxContainer = styled(Box)(({ theme }) => ({
  display: "flex",
  alignItems: "center",
  justifyContent: "center",
  flexDirection: "column",
  backgroundColor: "white",
  boxShadow: "10px 10px 20px 3px rgba(0, 0, 0, 0.6)",
  borderRadius: "20px",
  width: "570px",
  height: "500px",
}));

const RegisterTextContainer = styled(Typography)(({ theme }) => ({
  position: "relative",
  paddingBottom: "40px",
  fontWeight: "600",
}));

const ImageContainer = styled(CardMedia)(({ theme }) => ({
  position: "relative",
  bottom: "1%",
  width: "60px",
}));

const RegisterText = styled(Typography)(({ theme }) => ({
  position: "relative",
  paddingTop: "50px",
  paddingBottom: "20px",
  fontSize: "15px",
  fontWeight: "800",
  color: "#1d77b8",
}));

const TextFieldContainer = styled("div")(({ theme }) => ({
  textAlign: "center",
}));

const NameSectionContainer = styled(Box)(({ theme }) => ({
  display: "flex",
  alignItems: "center",
  justifyContent: "space-between",
  width: "72%",
  paddingTop: "25px",
}));

const UsernameSectionContainer = styled(Box)(({ theme }) => ({
  display: "flex",
  alignItems: "center",
  justifyContent: "space-between",
  width: "72%",
  paddingTop: "25px",
}));

const RandomUsernameButton = styled(Button)(({ theme }) => ({}));

const EmailSectionContainer = styled(Box)(({ theme }) => ({
  display: "flex",
  alignItems: "center",
  justifyContent: "space-between",
  width: "72%",
  paddingTop: "25px",
}));

const PasswordSectionContainer = styled(Box)(({ theme }) => ({
  display: "flex",
  alignItems: "center",
  justifyContent: "space-between",
  width: "72%",
  paddingTop: "25px",
}));

const BirthdaySectionContainer = styled(Box)(({ theme }) => ({
  display: "flex",
  alignItems: "center",
  justifyContent: "left",
  width: "72%",
  paddingTop: "50px",
  paddingBottom: "30px",
}));

const SliderSection = styled(Slider)(({ theme }) => ({
  display: "flex",
  alignItems: "center",
  justifyContent: "center",
  textAlign: "center",
  minHeight: "50%",
  width: "100%",
}));

const SliderSectionContainer = styled("div")(({ theme }) => ({
  display: "flex",
  alignItems: "center",
  marginLeft: "13%",
}));

const ButtonsSectionContainer = styled(Box)(({ theme }) => ({
  display: "flex",
  alignItems: "center",
  justifyContent: "center",
  width: "72%",
  paddingTop: "50px",
}));

const Alert = forwardRef(function Alert(props, ref) {
  return <MuiAlert elevation={6} ref={ref} variant="filled" {...props} />;
});

const Register = (props) => {
  const [value, setValue] = useState(dayjs("2000-06-29"));
  const [open, setOpen] = useState(false);
  const [loadingButton, setloadingButton] = useState(false);
  const [wasSuccessful, setSucessState] = useState(false);
  const navigate = useNavigate();

  const onSubmit = (values, actions) => {
    console.log(values);
    console.log(actions);
    setloadingButton(true);

    axios
      .post("/api/account/register", JSON.stringify(values), {
        headers: {
          "Content-Type": "application/json",
        },
      })
      .then(
        (response) => {
          axios
            .post("/api/user", JSON.stringify(values), {
              headers: {
                "Content-Type": "application/json",
              },
            })
            .then(
              (response) => {
                setSucessState(true);
                setOpen(true);
                navigate("/");
              },
              (error) => {}
            );
        },
        (error) => {
          setSucessState(false);
          setOpen(true);
          setloadingButton(false);
        }
      );
  };

  //Alert

  const handleClose = (event, reason) => {
    setOpen(false);
    if (reason === "clickaway") {
      return;
    }
  };

  //Alert

  const formik = useFormik({
    initialValues: {
      name: "",
      surName: "",
      username: "",
      email: "",
      confirmEmail: "",
      password: "",
      confirmPassword: "",
      dateOfBirth: value.toString(),
    },
    validationSchema: BasicSchema,
    onSubmit,
  });

  console.log(formik.errors);

  const [values, setValues] = useState({
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

  const customSlider = createRef();

  const gotoNext = () => {
    customSlider.current.slickNext();
  };

  const gotoPrev = () => {
    customSlider.current.slickPrev();
  };

  const settings = {
    dots: false,
    infinite: false,
    speed: 350,
    slidesToShow: 1,
    slidesToScroll: 1,
    arrows: false,
    draggable: false,
    accessibility: false,
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
              ? "Rejestracja zako??czona pomy??lnie"
              : "Rejestracja nie powiod??a si??"}
          </Alert>
        </Snackbar>

        <form onSubmit={formik.handleSubmit}>
          <RegisterBoxContainer>
            <ImageContainer component="img" image={logo} alt="Olympus Movie" />

            <RegisterTextContainer variant="h6">
              Rejestracja
            </RegisterTextContainer>

            <Divider sx={{ width: "100%" }} />

            {/*////////////////////////////////////////////////////////////////////////////////////////////////*/}

            <SliderSection {...settings} ref={customSlider}>
              <SliderSectionContainer>
                <NameSectionContainer>
                  <AssignmentIndIcon
                    sx={
                      !formik.errors.name &&
                      formik.touched.name &&
                      !formik.errors.surName &&
                      formik.touched.surName
                        ? { color: "green" }
                        : { color: "#625858" }
                    }
                  />

                  <TextFieldContainer>
                    <FormControl
                      size="small"
                      variant="standard"
                      error={
                        formik.errors.name && formik.touched.name ? true : false
                      }
                      sx={{ minWidth: "150px" }}
                    >
                      <InputLabel
                        htmlFor="standard-adornment-password"
                        sx={{ fontSize: "15px" }}
                      >
                        Imi??
                      </InputLabel>
                      <Input
                        value={formik.values.name}
                        onChange={formik.handleChange}
                        onBlur={formik.handleBlur}
                        id="name"
                        sx={{ fontSize: "15px" }}
                      />
                    </FormControl>
                  </TextFieldContainer>

                  <TextFieldContainer>
                    <FormControl
                      size="small"
                      variant="standard"
                      error={
                        formik.errors.surName && formik.touched.surName
                          ? true
                          : false
                      }
                      sx={{ minWidth: "150px" }}
                    >
                      <InputLabel
                        htmlFor="standard-adornment-password"
                        sx={{ fontSize: "15px" }}
                      >
                        Nazwisko
                      </InputLabel>
                      <Input
                        value={formik.values.surName}
                        onChange={formik.handleChange}
                        onBlur={formik.handleBlur}
                        id="surName"
                        sx={{ fontSize: "15px" }}
                      />
                    </FormControl>
                  </TextFieldContainer>
                </NameSectionContainer>

                <UsernameSectionContainer>
                  <FaceIcon
                    sx={
                      !formik.errors.username && formik.touched.username
                        ? { color: "green" }
                        : { color: "#625858" }
                    }
                  />

                  <TextFieldContainer>
                    <FormControl
                      size="small"
                      variant="standard"
                      error={
                        formik.errors.username && formik.touched.username
                          ? true
                          : false
                      }
                      style={{ minWidth: "220px" }}
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

                  <RandomUsernameButton
                    variant="contained"
                    sx={{
                      fontSize: "14px",
                      backgroundColor: "#201c1c",
                      borderRadius: "15px",
                      width: "130px",
                    }}
                    onClick={() => {
                      console.log(NicknameGenerator(formik));
                    }}
                  >
                    <CasinoIcon></CasinoIcon>&nbsp; Wylosuj
                  </RandomUsernameButton>
                </UsernameSectionContainer>
                {/*{console.log("Touched: " + formik.touched.username + "\nValue: " + formik.values.username)}*/}
                <Box
                  sx={{
                    display: "flex",
                    alignItems: "center",
                    justifyContent: "right",
                    width: "72%",
                    paddingTop: "50px",
                  }}
                >
                  <Button
                    variant="contained"
                    disabled={
                      !formik.errors.username &&
                      formik.touched.username &&
                      formik.values.username != "" &&
                      !formik.errors.name &&
                      formik.touched.name &&
                      formik.values.name != "" &&
                      !formik.errors.surName &&
                      formik.touched.surName &&
                      formik.values.surName != ""
                        ? false
                        : true
                    }
                    onClick={gotoNext}
                  >
                    Dalej
                  </Button>
                </Box>
              </SliderSectionContainer>

              <SliderSectionContainer>
                <EmailSectionContainer>
                  <EmailIcon
                    sx={
                      !formik.errors.email &&
                      formik.touched.email &&
                      !formik.errors.confirmEmail &&
                      formik.touched.confirmEmail
                        ? { color: "green" }
                        : { color: "#625858" }
                    }
                  />

                  <TextFieldContainer>
                    <FormControl
                      size="small"
                      variant="standard"
                      error={
                        formik.errors.email && formik.touched.email
                          ? true
                          : false
                      }
                      style={{ minWidth: "150px" }}
                    >
                      <InputLabel
                        htmlFor="standard-adornment-password"
                        sx={{ fontSize: "15px" }}
                      >
                        Adres e-mail
                      </InputLabel>
                      <Input
                        value={formik.values.email}
                        onChange={formik.handleChange}
                        onBlur={formik.handleBlur}
                        id="email"
                        sx={{ fontSize: "15px" }}
                      />
                    </FormControl>
                  </TextFieldContainer>

                  <TextFieldContainer>
                    <FormControl
                      size="small"
                      variant="standard"
                      error={
                        formik.errors.confirmEmail &&
                        formik.touched.confirmEmail
                          ? true
                          : false
                      }
                      style={{ minWidth: "150px" }}
                    >
                      <InputLabel
                        htmlFor="standard-adornment-password"
                        sx={{ fontSize: "15px" }}
                      >
                        Potwierd?? adres e-mail
                      </InputLabel>
                      <Input
                        value={formik.values.confirmEmail}
                        onChange={formik.handleChange}
                        onBlur={formik.handleBlur}
                        id="confirmEmail"
                        sx={{ fontSize: "15px" }}
                      />
                    </FormControl>
                  </TextFieldContainer>
                </EmailSectionContainer>

                <PasswordSectionContainer>
                  <LockIcon
                    sx={
                      !formik.errors.password &&
                      formik.touched.password &&
                      !formik.errors.confirmPassword &&
                      formik.touched.confirmPassword
                        ? { color: "green" }
                        : { color: "#625858" }
                    }
                  />

                  <TextFieldContainer>
                    <FormControl
                      size="small"
                      variant="standard"
                      error={
                        formik.errors.password && formik.touched.password
                          ? true
                          : false
                      }
                      style={{ maxWidth: "170px" }}
                    >
                      <InputLabel
                        htmlFor="standard-adornment-password"
                        sx={{ fontSize: "15px" }}
                      >
                        Has??o
                      </InputLabel>
                      <Input
                        sx={{ fontSize: "15px" }}
                        id="standard-adornment-password"
                        type={values.showPassword ? "text" : "password"}
                        value={formik.values.password}
                        onChange={formik.handleChange}
                        onBlur={formik.handleBlur}
                        id="password"
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

                  <TextFieldContainer>
                    <FormControl
                      size="small"
                      variant="standard"
                      error={
                        formik.errors.confirmPassword &&
                        formik.touched.confirmPassword
                          ? true
                          : false
                      }
                      style={{ maxWidth: "170px" }}
                    >
                      <InputLabel
                        htmlFor="standard-adornment-password"
                        sx={{ fontSize: "15px" }}
                      >
                        Potwierd?? has??o
                      </InputLabel>
                      <Input
                        sx={{ fontSize: "15px" }}
                        id="standard-adornment-password"
                        type={values.showPassword ? "text" : "password"}
                        value={formik.values.confirmPassword}
                        onChange={formik.handleChange}
                        onBlur={formik.handleBlur}
                        id="confirmPassword"
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
                </PasswordSectionContainer>

                <ButtonsSectionContainer>
                  <Button onClick={gotoPrev}>Wstecz</Button>
                  <Button
                    variant="contained"
                    onClick={gotoNext}
                    disabled={
                      !formik.errors.email &&
                      formik.touched.email &&
                      formik.values.email != "" &&
                      !formik.errors.confirmEmail &&
                      formik.touched.confirmEmail &&
                      formik.values.confirmEmail != "" &&
                      !formik.errors.password &&
                      formik.touched.password &&
                      formik.values.password != "" &&
                      !formik.errors.confirmPassword &&
                      formik.touched.confirmPassword &&
                      formik.values.confirmPassword != ""
                        ? false
                        : true
                    }
                    sx={{ marginLeft: "auto" }}
                  >
                    Dalej
                  </Button>
                </ButtonsSectionContainer>
              </SliderSectionContainer>

              <SliderSectionContainer>
                <BirthdaySectionContainer>
                  <CakeIcon sx={{ color: "#625858" }} />
                  <Box sx={{ marginLeft: "20%" }}>
                    <FormControl>
                      <LocalizationProvider dateAdapter={AdapterDayjs}>
                        <DesktopDatePicker
                          label="Data urodzenia"
                          value={value}
                          minDate={dayjs("1900-01-01")}
                          onChange={(newValue) => {
                            setValue(newValue);
                            formik.values.dateOfBirth = newValue.toString();
                          }}
                          renderInput={(params) => <TextField {...params} />}
                        />
                      </LocalizationProvider>
                    </FormControl>
                  </Box>
                </BirthdaySectionContainer>

                <ButtonsSectionContainer>
                  <Button onClick={gotoPrev}>Wstecz</Button>
                  <Button
                    type="submit"
                    variant="contained"
                    disabled={!loadingButton ? false : true}
                    onClick={gotoNext}
                    sx={{ marginLeft: "auto" }}
                  >
                    {!loadingButton ? "Zako??cz" : "??adowanie"}
                  </Button>
                </ButtonsSectionContainer>
              </SliderSectionContainer>
            </SliderSection>

            {/*////////////////////////////////////////////////////////////////////////////////////////////////*/}

            {/*                    <Button variant="contained" sx={{ fontSize: "14px", backgroundColor: "#201c1c", borderRadius: "15px", width: "180px" }}>Zarejestruj si??</Button>

                        <RegisterText variant="h7" >Nie masz jeszcze konta?
                            &nbsp;
                            <Link to="/Register" >Za?????? je tutaj!</Link>
                        </RegisterText>*/}
          </RegisterBoxContainer>
        </form>
      </Container>
    </>
  );
};

export default Register;
