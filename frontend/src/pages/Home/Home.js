import Slider from 'react-slick';
import styles from "./Slider.module.css";
import avatar from "./avatar.jpg";
import coco from "./coco.jpg";
import listydom from "./listydom.jpg";
import homealone from "./homealone.jpg";

const SimpleSlider = () => {
    const settings = {
        dots: true,
        infinite: true,
        speed: 500,
        slidesToShow: 3,
        slidesToScroll: 1
    };
    return (
        <div className={styles.Slider}>
            <h2 className={styles.Title}>Filmowe nowości</h2>
            <Slider {...settings}>
                <div className={styles.Cover}>
                    <div className={styles.CoverChild}><img src={avatar}></img></div>
                    <div className={styles.Description}>
                        <h2>Avatar: Istota wody</h2>
                        <div className={styles.Rating}>&nbsp;&nbsp;8/10⭐</div>
                    </div>
                </div>

                <div className={styles.Cover}>
                    <div className={styles.CoverChild}><img src={coco}></img></div>
                    <div className={styles.Description}>
                        <h2>Coco</h2>
                        <div className={styles.Rating}>&nbsp;&nbsp;9.5/10⭐</div>
                    </div>
                </div>

                <div className={styles.Cover}>
                    <div className={styles.CoverChild}><img src={listydom}></img></div>
                    <div className={styles.Description}>
                        <h2>Listy do M</h2>
                        <div className={styles.Rating}>&nbsp;&nbsp;7.5/10⭐</div>
                    </div>
                </div>

                <div className={styles.Cover}>
                    <div className={styles.CoverChild}><img src={homealone}></img></div>
                    <div className={styles.Description}>
                        <h2>Kevin sam w domu</h2>
                        <div className={styles.Rating}>&nbsp;&nbsp;8.5/10⭐</div>
                    </div>
                </div>
            </Slider>
        </div>
    );
}

export default SimpleSlider;