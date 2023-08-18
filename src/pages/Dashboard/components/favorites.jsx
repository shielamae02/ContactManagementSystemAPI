import FavoritesCard from "./favorites_card";

const FavoritesSection = () => {
    return (
        <div className="p-6 gap-2 flex flex-col w-full">
            <div className="flex items-center justify-between">
                <h1 className="text-2xl font-bold text-blue">
                    Favorites
                </h1>
                <h3 className="text-mistyBlue underline underline-offset-4 cursor-pointer">see all</h3>
            </div>
            <div className="flex flex-grow gap-4">
                <FavoritesCard />
                <FavoritesCard />
                <FavoritesCard />
            </div>
      </div>
    );
}

export default FavoritesSection;