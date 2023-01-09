import React from "react";


export default function NicknameGenerator(formik) {

    //formik.values.name, formik.values.surName, formik.values.username, formik.setFieldValue, formik.touched.username

    if (formik.values.name === "" || formik.values.surName === "")
        return "test";

    const firstSeq = formik.values.name.substring(0, Math.floor(Math.random() * formik.values.name.length) + 1);
    const secondSeq = formik.values.surName.substring(0, Math.floor(Math.random() * formik.values.surName.length) + 1);

    if (firstSeq.length + secondSeq.length < 4)
        formik.values.username = firstSeq + secondSeq + ((Math.floor(Math.random() * 900) + 1) + 100);
    else
        formik.values.username = firstSeq + secondSeq + (Math.floor(Math.random() * 1000) + 1);
    
    formik.setFieldTouched('username', true);

    formik.setFieldValue('username', formik.values.username);

    return formik.values.username;

}