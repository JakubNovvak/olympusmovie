import * as yup from "yup";

const passwordRules = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{5,}$/

export const BasicSchema = yup.object().shape({
    name: yup.string().min(5).required("Wymagane"),
    surName: yup.string().min(5).required("Wymagane"),
    username: yup.string().min(5).required("Wymagane"),
    email: yup.string().email("Proszę podać prawidłowy adres e-mail").required("Wymagane"),
    password: yup.string().min(5).matches(passwordRules, { message: "Hasło jest za słabe" }).required("Wymagane"),
    confirmEmail: yup
        .string()
        .oneOf([yup.ref('email'), null], "Adresy e-mail muszą być takie same").required("Wymagane"),
    confirmPassword: yup
        .string()
        .oneOf([yup.ref('password'), null], "Hasła muszą być takie same").required("Wymagane"),
    dateOfBirth: yup
        .date()
})